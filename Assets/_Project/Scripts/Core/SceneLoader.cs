using UnityEngine;
using UnityEngine.SceneManagement; // 必须引入场景管理命名空间

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // --- 新增的加载方法 ---
    public void LoadScene(string sceneName)
    {
        // 使用Unity的场景管理器来加载场景
        SceneManager.LoadScene(sceneName);
    }
}