using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whip : MonoBehaviour
{
    [SerializeField] float duration = 4f;
    float timer;

    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);
    [SerializeField] int damage = 1;

    [SerializeField] GameObject leftSwordObject;
    [SerializeField] GameObject rightSwordObject;
    PlayerMove playerMove;

    private void Awake() {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.Spacebar) { Attack() };
        timer -= Time.deltaTime;
        if (timer < 0f) {
            Attack();
        }
    } 

    private void Attack() {
        timer = duration;
        if (playerMove.lastHorizontalVector > 0) {
            rightSwordObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightSwordObject.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
        else {
            leftSwordObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftSwordObject.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
        
    }

    private void ApplyDamage(Collider2D[] colliders) {
        for (int i = 0; i < colliders.Length; i++) {
            Enemy e = colliders[i].GetComponent<Enemy>();
            if (e != null) {
                e.TakeDamage(damage);
            }
        }
    }
}
