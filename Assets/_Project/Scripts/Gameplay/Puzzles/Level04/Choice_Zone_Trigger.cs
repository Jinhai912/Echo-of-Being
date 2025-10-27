using UnityEngine;

public class Choice_Zone_Trigger : MonoBehaviour
{
    [Tooltip("请把场景中的Canvas对象拖拽到这里")]
    [SerializeField] private GameObject choiceCanvas;

    private void OnTriggerEnter(Collider other)
    {
        // 检查进来的是不是玩家
        if (other.CompareTag("Player"))
        {
            Debug.Log("玩家已进入最终选择区域。");
            // 激活Canvas，让UI显示出来
            choiceCanvas.SetActive(true);

            // 同时，为了防止玩家做出选择后还能到处乱跑，
            // 并且为了让鼠标能点击按钮，我们把鼠标解锁并显示出来
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // （可选）我们甚至可以禁用玩家的移动控制器，让其完全静止
            if (other.TryGetComponent(out PlayerController playerController))
            {
                playerController.enabled = false;
            }
        }
    }
}