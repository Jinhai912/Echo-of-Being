using UnityEngine;

public class Puzzle_Interactable_Key : MonoBehaviour, IInteractable
{
    public string InteractionPrompt => "拾取能量核心";

    public void Interact(GameObject interactor)
    {
        // 1. 调用“关卡大脑”的公共方法，告诉它钥匙被拿走了
        Level02_Controller.Instance.OnKeyCollected();

        // 2. 打印日志，方便我们测试
        Debug.Log("玩家拾取了道具！");

        // 3. 拾取后，钥匙就应该消失
        Destroy(gameObject);
    }
}