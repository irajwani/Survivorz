using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb2d;
    [HideInInspector] public Vector2 movementVector;
    [HideInInspector] public float lastHorizontalVector;
    [HideInInspector] public float lastVerticalVector;
    [SerializeField] float speed = 3f;
    Animate animate;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector2();
        animate = GetComponent<Animate>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        UpdateLastMovementVector();
        HandleMove();
        Debug.Log("Player Pos: " + movementVector);
    }

    private void HandleMove() {
        animate.horizontal = movementVector.x;

        movementVector *= speed;
        rb2d.MovePosition(rb2d.position + movementVector * Time.fixedDeltaTime);
    }

    private void UpdateLastMovementVector() {
        if (movementVector.x != 0) {
            lastHorizontalVector = movementVector.x;
        }
        if (movementVector.y != 0) {
            lastVerticalVector = movementVector.y;
        }
    }
}
