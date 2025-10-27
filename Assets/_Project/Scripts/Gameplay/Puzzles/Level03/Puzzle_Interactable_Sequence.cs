using UnityEngine;

public class Puzzle_Interactable_Sequence : MonoBehaviour, IInteractable
{
    [Tooltip("设置这个交互点的ID (例如: 1, 2, 3...)")]
    [SerializeField] private int sequenceID;

    public string InteractionPrompt => "激活节点 " + sequenceID;

    public void Interact(GameObject interactor)
    {
        // 调用关卡大脑的方法，并把自己的ID传过去
        Level03_Controller.Instance.OnSequenceButtonPressed(sequenceID);
        // 为了防止重复点击，激活后就禁用自己
        //gameObject.SetActive(false);
    }
}