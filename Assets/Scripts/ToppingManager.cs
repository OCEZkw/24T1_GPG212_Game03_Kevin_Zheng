using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToppingManager : MonoBehaviour
{
    private int jellyCount = 0;
    private int pearlCount = 0;

    public TextMeshProUGUI jellyCountText;
    public TextMeshProUGUI pearlCountText;
    public OrderManager orderManager; // Reference to the OrderManager script

    public int JellyCount => jellyCount;
    public int PearlCount => pearlCount;

    public void ResetCounts()
    {
        jellyCount = 0;
        pearlCount = 0;
        UpdateToppingCounts();
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
        else if (other.CompareTag("Virus"))
        {
            // Subtract 7 points from the score
            orderManager.Score -= 7;
            Debug.Log("Virus hit! Score: " + orderManager.Score);

            // Update the score text on the screen
            orderManager.UpdateScoreText();
        }
        UpdateToppingCounts();

        // Destroy the collided topping object
        Destroy(other.gameObject);
    }

    private void UpdateToppingCounts()
    {
        if (jellyCountText != null)
        {
            jellyCountText.text = "Jelly: " + jellyCount;
        }

        if (pearlCountText != null)
        {
            pearlCountText.text = "Pearl: " + pearlCount;
        }
    }
}