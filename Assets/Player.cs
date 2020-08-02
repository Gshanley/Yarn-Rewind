using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputMaster controls;
    Vector2 move;

    void Awake()
    {
        controls = new InputMaster();
        controls.GamePlay.Movement.performed += HandleMovement;
        controls.GamePlay.Movement.canceled += ctx => move = Vector2.zero;
    }

    void HandleMovement(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        // Debug.Log($"Moving {move}");
    }

    void Update()
    {
        Vector3 m = new Vector3(move.x, 0, move.y) * Time.deltaTime;
        transform.Translate(m);
    }

    void OnEnable()
    {
        controls.GamePlay.Enable();
        controls.GamePlay.Movement.performed += HandleMovement;
    }

    private void OnDisable()
    {
        controls.GamePlay.Disable();
    }
}
