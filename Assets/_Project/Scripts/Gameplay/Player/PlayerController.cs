using UnityEngine;

// 确保这个脚本挂载的对象一定有 CharacterController 组件
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f; // 可以在Unity编辑器里调整的移动速度

    private CharacterController controller;

    private void Awake()
    {
        // 在游戏开始时，获取对 CharacterController 组件的引用
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // 1. 从 InputManager 获取移动输入数据
        Vector2 input = InputManager.Instance.GetMoveInput();

        // 2. 将二维的输入向量，转换为三维的世界空间移动方向
        // (input.x 对应左右, input.y 对应前后)
        Vector3 moveDirection = new Vector3(input.x, 0f, input.y);

        // 3. 使用 CharacterController 的 Move 方法来执行移动
        // Time.deltaTime 确保移动速度与帧率无关
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}