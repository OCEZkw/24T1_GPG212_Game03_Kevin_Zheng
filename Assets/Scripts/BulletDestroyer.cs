using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jelly") || other.CompareTag("Virus") || other.CompareTag("Pearl"))
        {
            Destroy(other.gameObject); // Destroy the bullet when it enters the trigger zone
        }
    }
}
