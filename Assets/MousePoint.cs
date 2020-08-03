using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePoint : MonoBehaviour
{
    public GameObject temp;
    public GameObject floor;

    void Update()
    {
        //Vector3 mouse = Mouse.current.position;
        Vector2 Mousepoint = Camera.main.ScreenToWorldPoint(Mouse.current.position);
        Debug.Log(Mousepoint);
        Debug.Log(Input.mousePosition);
        Vector3 dir = Mousepoint - Camera.main.transform.position;

        RaycastHit hit;
        Physics.Raycast(Mousepoint, dir, out hit);
        temp.transform.position = hit.point;
    }
}
