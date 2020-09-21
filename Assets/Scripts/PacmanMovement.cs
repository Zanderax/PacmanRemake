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
        // HandleMovementInput();

        // Hardcoded Movement for Assignment 3
        if(CurrentDirection == MovementDirection.Left && transform.position.x < -11.2)
        {
            CurrentDirection = MovementDirection.Up;
        }
        if(CurrentDirection == MovementDirection.Up && transform.position.y > 7.2)
        {
            CurrentDirection = MovementDirection.Right;
        }
        if(CurrentDirection == MovementDirection.Right && transform.position.x > -7.2)
        {
            CurrentDirection = MovementDirection.Down;
        }
        if(CurrentDirection == MovementDirection.Down && transform.position.y < 4)
        {
            CurrentDirection = MovementDirection.Left;
        }
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
    private MovementDirection CurrentDirection = MovementDirection.Left;

    private Rigidbody2D RigidBody;
}
