using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class OrderManager : MonoBehaviour
{
    public Image[] images; // Array to hold the images representing topping combinations
    public Button deliveryButton; // Button to deliver the order
    public TMP_Text scoreText; // TextMeshPro text to display the score
    public ToppingManager toppingManager; // Reference to the ToppingManager script

    private int currentOrderIndex; // Index of the current order being displayed
    private int score; // Player's score
    private float orderTimer; // Timer for the order duration

    private void Start()
    {
        score = 0;
        UpdateScoreText();
        NextOrder();
    }

    private void Update()
    {
        orderTimer -= Time.deltaTime;
        if (orderTimer <= 0f)
        {
            // Time ran out, move to next order
            NextOrder();
        }
    }

    // Function to generate a new order
    private void NextOrder()
    {
        currentOrderIndex = Random.Range(0, images.Length);
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(i == currentOrderIndex);
        }
        orderTimer = 10f;
    }

    // Function to handle delivery button press
    public void DeliverOrder()
    {
        int pearls = toppingManager.PearlCount;
        int jelly = toppingManager.JellyCount;

        if ((currentOrderIndex == 0 && pearls == 3) ||
            (currentOrderIndex == 1 && pearls == 2 && jelly == 1) ||
            (currentOrderIndex == 2 && jelly == 3))
        {
            score += 10;
        }
        else
        {
            score -= 5;
        }

        // Reset topping count regardless of the order outcome
        toppingManager.ResetCounts();

        UpdateScoreText();
        NextOrder();
    }

    // Function to update score text
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}