using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingManager : MonoBehaviour
{
    private int jellyCount = 0;
    private int pearlCount = 0;

    public int JellyCount => jellyCount;
    public int PearlCount => pearlCount;

    public void ResetCounts()
    {
        jellyCount = 0;
        pearlCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has a tag "Jelly" or "Pearl"
        if (other.CompareTag("Jelly"))
        {
            jellyCount++;
            Debug.Log("Jelly caught: " + jellyCount);
        }
        else if (other.CompareTag("Pearl"))
        {
            pearlCount++;
            Debug.Log("Pearl caught: " + pearlCount);
        }

        // Destroy the collided topping object
        Destroy(other.gameObject);
    }
}
