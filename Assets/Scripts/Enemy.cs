using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDestructible
{
    Transform targetDestination;
    [SerializeField] float speed;
    [SerializeField] int hp = 20;
    [SerializeField] int damage = 10;
    [SerializeField] int experienceReward = 300;

    Rigidbody2D rb2d;

    GameObject targetGameObject;
    Character targetCharacter;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb2d.velocity = direction * speed;
    }

    public void SetTarget(GameObject target) {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject == targetGameObject) {
            Attack();
        }
    }

    private void Attack() {
        if (targetCharacter == null) {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage) {
        hp -= damage;
        if (hp < 1) {
            targetGameObject.GetComponent<Level>().AddExperience(experienceReward);
            Destroy(gameObject);
        }
    }

}
