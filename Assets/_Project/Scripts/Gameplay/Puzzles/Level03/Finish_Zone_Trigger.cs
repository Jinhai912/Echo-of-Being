using UnityEngine;

public class Finish_Zone_Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 检查是不是玩家
        if (other.CompareTag("Player"))
        {
            // 新增：检查“关卡大脑”里的谜题状态
            if (Level03_Controller.Instance.isBridgeBuilt)
            {
                Debug.Log("玩家已到达终点！第三关通过！");
                // 假设第四关叫 "Level_04_BeiMing_Return"
                SceneLoader.Instance.LoadScene("Level_04_BeiMing_Return");
            }
            else
            {
                Debug.Log("桥还没建好，无法通过！");
            }
        }
    }
}