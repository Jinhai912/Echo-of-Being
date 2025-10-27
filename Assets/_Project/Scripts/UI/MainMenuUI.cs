using UnityEngine;

// 这个脚本将挂载在主菜单场景中，负责处理该场景的UI逻辑
public class MainMenuUI : MonoBehaviour
{
    // 这是一个公共方法，我们将把它链接到按钮的点击事件上
    public void OnStartGameButtonClicked()
    {
        // 打印一条日志，方便我们验证按钮是否被成功点击
        Debug.Log("“开始游戏”按钮被点击了！");

        // 调用我们核心系统里的场景加载器，去加载第一个关卡
        // 注意：这里我们硬编码了场景名字，确保它和你的关卡场景文件名一致
        SceneLoader.Instance.LoadScene("Level_01_BeiMing");
    }
}