using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb2d;
    [HideInInspector] public Vector3 movementVector;

    [HideInInspector] public float lastHorizontalVector;
    [HideInInspector] public float lastVerticalVector;
    [SerializeField] float speed = 3f;
    Animate animate;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        animate = GetComponent<Animate>();
    }
    // Start is called before the first frame update
    // void Start()
    // {
    //     rb2d.velocity = { x: 4, y: -8};
    // }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        UpdateLastMovementVector();

        animate.horizontal = movementVector.x;

        movementVector *= speed;

        rb2d.velocity = movementVector;
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
