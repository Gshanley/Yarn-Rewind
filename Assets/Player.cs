using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputMaster controls;
    Vector2 move;
    Vector2 rot;

    public GameObject test;
    public GameObject test1;
    public float speed = 1;

    void Awake()
    {
        controls = new InputMaster();
        controls.GamePlay.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.GamePlay.Movement.canceled += ctx => move = Vector2.zero;
        controls.GamePlay.Rotation.performed += ctx => rot = ctx.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 m = new Vector3(move.x, 0, move.y) * Time.deltaTime * speed;
        transform.Translate(m, Space.World);

        Debug.Log(rot);
        Vector3 mouse3 = worldPos(rot);
        Vector2 mouse2 = new Vector2(mouse3.x, mouse3.z);
        Vector2 Pos = new Vector2(transform.position.x, transform.position.z);

        transform.LookAt(mouse3);

        //DrawLine(Camera.main.transform.position, mouse3, Color.red);
    }

    float AngleTo(Vector2 pos, Vector2 target)
    {
        Vector2 diference = target - pos;
        float sign = (target.y < pos.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }

   Vector3 worldPos(Vector2 pos)
    {
        Vector3 Mpos = Vector3.zero;
        
        Vector3 Pos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, Camera.main.nearClipPlane));

        RaycastHit hit;
        Vector3 dir = Pos - Camera.main.transform.position;
        //Vector2 M = Vector3.zero;
        Physics.Raycast(Pos, dir, out hit);

        Vector3 M = new Vector3(hit.point.x, 0.5f, hit.point.z);
        
        return M;
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
