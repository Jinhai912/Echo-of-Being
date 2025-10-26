// 定义了一个“可交互”对象的行为规范
public interface IInteractable
{
    // 显示给玩家的交互提示文本，例如 "捡起葫芦"
    string InteractionPrompt { get; }

    // 当玩家与此对象交互时，执行此方法
    // 参数 interactor 通常是玩家对象，方便交互对象知道是谁在与它互动
    void Interact(UnityEngine.GameObject interactor);
}