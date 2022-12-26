using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    float disableAfter = 0.8f;
    float timer;

    private void OnEnable() {
        timer = disableAfter;
    }

    private void LateUpdate() {
         timer -= Time.deltaTime;
         if (timer < 0f) {
            gameObject.SetActive(false);
         }
    }
}
