using System.Collections.Generic;
using UnityEngine;

public class Level03_Controller : MonoBehaviour
{
    public static Level03_Controller Instance { get; private set; }

    // 用一个列表来记录玩家按下的顺序
    private List<int> sequencePressed = new List<int>();
    
    // 新增：一个简单的布尔值，代表桥是否存在
    public bool isBridgeBuilt { get; private set; } = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // 公共方法，让交互点按钮可以调用
    public void OnSequenceButtonPressed(int buttonID)
    {
        Debug.Log("玩家按下了顺序按钮：" + buttonID);
        sequencePressed.Add(buttonID);
        CheckSequence();
    }

    private void CheckSequence()
    {
        // 检查是否已按下两个按钮
        if (sequencePressed.Count < 2) return;

        // 我们设定的正确顺序是：先按1，再按2
        if (sequencePressed[0] == 1 && sequencePressed[1] == 2)
        {
            Debug.Log("顺序正确！谜题解开，桥现在可以'通过'了。");
            isBridgeBuilt = true; // 谜题解开，把状态设为true
        }
        else
        {
            Debug.Log("顺序错误，重置谜题。");
            sequencePressed.Clear(); // 清空列表，让玩家重新开始
        }
    }
}