using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public InputActionAsset inputAsset;
    private InputActionMap inputMap;
    private InputAction move;

    public float speed = 5f;
    private CharacterController controller;

    public void SetupInputAsset(InputActionAsset inputAsset)
    {
        this.inputAsset = inputAsset;
        InitInput();
    }

    void InitInput()
    {
        controller = GetComponent<CharacterController>();
        inputMap = inputAsset.FindActionMap("Player");
        move = inputMap.FindAction("Move");
    }


    void Update()
    {
        if(move == null)
        {
            InitInput();
            return;
        }

        Vector2 moveValue = move.ReadValue<Vector2>();
        Vector3 movement = transform.forward * moveValue.y + transform.right * moveValue.x;
        controller.Move(movement * speed * Time.deltaTime);
    }
}
