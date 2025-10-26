using UnityEngine;

// 这个脚本的唯一使命，就是在游戏启动时，加载第一个真正的游戏关卡
public class Bootstrapper : MonoBehaviour
{
    // 在Start方法中执行，可以确保所有核心系统的Awake方法都已执行完毕
    void Start()
    {
        // 调用SceneLoader单例，加载我们的第一个游戏关卡
        // 注意：这里的场景名字 "Level_01_BeiMing" 必须和你创建的场景文件名完全一致
        SceneLoader.Instance.LoadScene("Level_01_BeiMing");
    }
}