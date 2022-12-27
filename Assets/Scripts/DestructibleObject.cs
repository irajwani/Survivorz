using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour, IDestructible
{
    // Start is called before the first frame update
    public void TakeDamage(int damage) {
        Destroy(gameObject);
    }
}
