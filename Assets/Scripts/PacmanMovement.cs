using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
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
        float MovementAmount = MovementSpeed * MovementFactor;
        switch(CurrentDirection)
        {
            case MovementDirection.Left:
            {
                transform.Translate(-MovementAmount, 0f, 0f, Space.World);
                break;
            }
            case MovementDirection.Right:
            {
                transform.Translate(MovementAmount, 0f, 0f, Space.World);
                break;
            }
            case MovementDirection.Down:
            {
                transform.Translate(0f, -MovementAmount, 0f, Space.World);
                break;
            }
            case MovementDirection.Up:
            {
                transform.Translate(0f, MovementAmount, 0f, Space.World);
                break;
            }

        }
    }

    private float MovementSpeed = 0.02f;
    private float MovementFactor = 1.0f;

    private enum MovementDirection
    {
        Still,
        Left,
        Right,
        Down,
        Up
    }
    private MovementDirection CurrentDirection = MovementDirection.Still;
}
