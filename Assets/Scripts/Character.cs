using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int hp = 1000;
    [SerializeField] StatusBar hpBar;


    public void TakeDamage(int damage) {
        hp -= damage;    
        Debug.Log("Your health:" + hp);
        if (hp <= 0) {
            Debug.Log("YOU DEAD!");
        }
        hpBar.SetState(hp, maxHp);
    }

    public void Heal(int health) {
        if (hp <= 0) {
            return;
        }
        hp += health;
        if (hp > maxHp) {
            hp = maxHp;
        }
    }
}
