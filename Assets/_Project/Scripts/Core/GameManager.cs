using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 静态实例，用于全局访问
    public static GameManager Instance { get; private set; }

    // 在对象加载时立即执行
    private void Awake()
    {
        // 单例
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // 如果已存在实例，则销毁此重复对象
        }
    }
}