using UnityEngine;

public class GourdController : MonoBehaviour, IInteractable
{
    public string InteractionPrompt => "与葫芦交互";

    public void Interact(GameObject interactor)
    {
        // 在控制台打印一条信息，来验证交互是否成功
        Debug.Log(interactor.name + " 正在与葫芦交互！");

        
    }
}