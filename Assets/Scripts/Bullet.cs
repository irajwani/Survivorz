using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    public GameObject hitEffect;
    public float hitEffectDuration = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Quaternion.idenity = no rotation
        Debug.Log("collision with" + collision.gameObject);
        
        DestroyBullet();
    }

    void DestroyBullet(float offset = 0f) {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, hitEffectDuration + offset);
        Destroy(gameObject);
    }
}
