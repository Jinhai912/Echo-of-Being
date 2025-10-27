using UnityEngine;

public class Puzzle_Interactable_Soul : MonoBehaviour, IInteractable
{
    public string InteractionPrompt => "与灵魂交互";

    public void Interact(GameObject interactor)
    {
        // 1. 询问“关卡大脑”，玩家是否有钥匙
        if (Level02_Controller.Instance.playerHasKey)
        {
            // 如果有钥匙，则谜题解决
            Debug.Log("谜题解决！灵魂被解放了！正在前往第三关...");

            // 为了打通流程，我们先假设第三关的场景名叫 "Level_03_NanMing"
            // 注意：因为这个场景还不存在，所以点击后会报错，这是完全正常的
            SceneLoader.Instance.LoadScene("Level_03_NanMing");
        }
        else
        {
            // 如果没有钥匙，则给出提示
            Debug.Log("灵魂似乎被某种能量束缚着，无法靠近...");
        }
    }
}