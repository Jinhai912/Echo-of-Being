using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [Header("交互设置")]
    [Tooltip("以玩家为中心，检测可交互物的半径")]
    [SerializeField] private float interactionRadius = 1.5f; // “交互气泡”的半径

    // Unity 编辑器生命周期函数，方便我们在场景视图中看到这个“气泡”的范围
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    private void OnEnable()
    {
        InputManager.OnInteractAction += PerformInteractionCheck;
    }

    private void OnDisable()
    {
        InputManager.OnInteractAction -= PerformInteractionCheck;
    }

    private void PerformInteractionCheck()
    {
        // 核心改动：不再使用射线，而是使用“重叠球体”检测
        // Physics.OverlapSphere 会返回一个数组，包含所有与指定球体接触的碰撞体
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRadius);

        // 为了防止同时与多个物体交互，我们只选择最近的那个
        float closestDistance = float.MaxValue;
        IInteractable closestInteractable = null;

        // 遍历所有在“气泡”内的物体
        foreach (Collider collider in colliders)
        {
            // 检查这个物体上是否有 IInteractable 接口
            if (collider.TryGetComponent(out IInteractable interactableObject))
            {
                // 计算玩家与这个物体的距离
                float distance = Vector3.Distance(transform.position, collider.transform.position);

                // 如果这个物体比我们之前找到的“最近的”还要近
                if (distance < closestDistance)
                {
                    // 就更新“最近的”记录
                    closestDistance = distance;
                    closestInteractable = interactableObject;
                }
            }
        }

        // 循环结束后，如果找到了一个最近的可交互物
        if (closestInteractable != null)
        {
            // 就只与它进行交互
            closestInteractable.Interact(this.gameObject);
        }
    }
}