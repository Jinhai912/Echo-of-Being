using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public static event Action OnInteractAction;

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
    }
}
