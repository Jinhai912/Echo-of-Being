using UnityEngine;

public class Level04_UI_Controller : MonoBehaviour
{
    // 公共方法，用于链接到“A. 停留于此”按钮
    public void OnButtonStayClicked()
    {
        Debug.Log("玩家选择了【停留于此】。游戏结束。");
        // 在编辑器模式下，这行代码会停止播放
        // 在构建出的游戏中，这行代码会关闭程序
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // 公共方法，用于链接到“B. 跌入循环”按钮
    public void OnButtonLoopClicked()
    {
        Debug.Log("玩家选择了【跌入循环】。重新开始旅程...");
        // 直接加载我们游戏的主菜单场景，实现完美的循环
        SceneLoader.Instance.LoadScene("MainMenu");
    }
    
}