using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Camera cam;
    Vector3 mousePos;
    public float offset = 0.1f;
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    private SpriteRenderer spriteRenderer;
    
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Keyboard.current.spaceKey.wasPressedThisFrame) {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }

        HandleRotate();
        Debug.Log("Gun Pos: " + transform.position + "Sp position: " + shootingPoint.position);
    }

    // void FixedUpdate() {
    //     HandleRotate();
    //     Debug.Log("Gun Pos: " + transform.position);
    // }

    private void HandleRotate() {
        Vector3 lookDir = mousePos - transform.position;
        float rotationZ = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offset);

        if (rotationZ < 89 && rotationZ > -89) {
            spriteRenderer.flipY = false;
        }
        else {
            spriteRenderer.flipY = true;
        }
    }
}
