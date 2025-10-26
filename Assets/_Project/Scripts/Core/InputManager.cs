using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public static event Action OnInteractAction;
    private Vector2 moveInput;

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
    void Update()
    {
        // 检查玩家是否按下了 'E' 键
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 如果按下了，就广播 OnInteractAction 事件
            // '?' 是一个安全检查，确保有脚本订阅了这个事件才广播，防止报错
            OnInteractAction?.Invoke();
        }

        moveInput.x = Input.GetAxis("Horizontal"); // A/D键 或 左右箭头
        moveInput.y = Input.GetAxis("Vertical");   // W/S键 或 上下箭头
    }

    public Vector2 GetMoveInput()
    {
        return moveInput;
    }
}
