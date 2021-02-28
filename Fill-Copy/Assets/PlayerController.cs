using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 Startposition;
    bool IsWalkable;
    Vector3 direction;
    public float speed;
    public Rigidbody rb;

    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Startposition = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        }
        if (Input.GetMouseButton(0))
        {
            direction = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y) - Startposition;
            IsWalkable = true;

        }
        if (Input.GetMouseButtonUp(0))
        {
            direction = Vector3.zero;
            IsWalkable = false;
        }

    }
    private void FixedUpdate()
    {
        Move();

        //Rotate();
    }

    private void Rotate()
    {
        if (IsWalkable)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.position + direction), Time.deltaTime);
            transform.LookAt(transform.position + direction, Vector3.up);
        }
    }

    private void Move()
    {
        if (IsWalkable)
        {
            if (direction.magnitude > .5f)
            {
                print("play" + direction.normalized);
                rb.velocity = (direction.normalized) * speed;
            }

        }
    }
}
