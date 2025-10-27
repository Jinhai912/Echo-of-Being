using UnityEngine;

public class Level02_Controller : MonoBehaviour
{
    // 使用单例模式，让这个关卡控制器可以被场景中的任何其他脚本轻松访问
    public static Level02_Controller Instance { get; private set; }

    // 这个变量是本关卡的“记忆”，用来记录玩家是否已经拿到了钥匙
    public bool playerHasKey = false;

    private void Awake()
    {
        // 标准的单例模式实现
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // 如果场景中已存在一个实例，则销毁此重复对象，保证唯一性
            Destroy(gameObject);
        }
    }

    // 提供一个公共方法，让“钥匙”脚本可以调用，用来更新我们的“记忆”
    public void OnKeyCollected()
    {
        playerHasKey = true;
        Debug.Log("【关卡控制器】已记录：玩家获得了钥匙。");
    }
}