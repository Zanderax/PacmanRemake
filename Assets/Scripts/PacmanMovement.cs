using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }

    void FixedUpdate()
    {
        DoMovement();
    }

    void HandleMovementInput()
    {
        if(Input.GetKeyDown("left"))
        {
            CurrentDirection = MovementDirection.Left;
            return;
        }
        if(Input.GetKeyDown("right"))
        {
            CurrentDirection = MovementDirection.Right;
            return;
        }
        if(Input.GetKeyDown("down"))
        {
            CurrentDirection = MovementDirection.Down;
            return;
        }
        if(Input.GetKeyDown("up"))
        {
            CurrentDirection = MovementDirection.Up;
            return;
        }
    }

    void DoMovement()
    {
        Vector2 velocity = new Vector2(0f, 0f);
        switch(CurrentDirection)
        {
            case MovementDirection.Left:
            {
                velocity = new Vector2(-MovementSpeed, 0f);
                break;
            }
            case MovementDirection.Right:
            {
                velocity = new Vector2(MovementSpeed, 0f);
                break;
            }
            case MovementDirection.Down:
            {
                velocity = new Vector2(0f, -MovementSpeed);
                break;
            }
            case MovementDirection.Up:
            {
                velocity = new Vector2(0f, MovementSpeed);
                break;
            }
        }
        RigidBody.MovePosition(RigidBody.position + velocity * Time.fixedDeltaTime);
    }

    private float MovementSpeed = 2.0f;

    private enum MovementDirection
    {
        Still,
        Left,
        Right,
        Down,
        Up
    }
    private MovementDirection CurrentDirection = MovementDirection.Still;

    private Rigidbody2D RigidBody;
}
