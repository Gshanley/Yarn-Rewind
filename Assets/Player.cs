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
        controls.GamePlay.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.GamePlay.Movement.canceled += ctx => move = Vector2.zero;
    }

    void Update()
    {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);
    }

    void OnEnable()
    {
        controls.GamePlay.Enable();
    }

    private void OnDisable()
    {
        controls.GamePlay.Disable();
    }
}
