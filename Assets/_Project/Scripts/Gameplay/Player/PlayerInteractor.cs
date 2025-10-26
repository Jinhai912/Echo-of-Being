using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [Header("交互设置")]
    [SerializeField] private float interactionDistance = 3f;
    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
    }

    // 当该组件被激活时调用 (比Start更早，且每次激活都调用)
    private void OnEnable()
    {
        // 向 InputManager “订阅” OnInteractAction 事件
        // 意思是：“当 OnInteractAction 事件发生时，请调用我的 PerformInteractionCheck 方法”
        InputManager.OnInteractAction += PerformInteractionCheck;
    }

    // 当该组件被禁用或销毁时调用
    private void OnDisable()
    {
        // 非常重要：必须“取消订阅”事件，否则可能导致内存泄漏和错误
        InputManager.OnInteractAction -= PerformInteractionCheck;
    }

    // 这个方法现在不再由 Update 调用，而是由 InputManager 的事件来触发
    private void PerformInteractionCheck()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactionDistance))
        {
            if (hitInfo.collider.TryGetComponent(out IInteractable interactableObject))
            {
                interactableObject.Interact(this.gameObject);
            }
        }
    }
}