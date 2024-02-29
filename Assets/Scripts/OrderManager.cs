using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OrderManager : MonoBehaviour
{
    public Image[] images; // Array to hold the images representing topping combinations
    public Button deliveryButton; // Button to deliver the order
    public TMP_Text scoreText; // TextMeshPro text to display the score
    public ToppingManager toppingManager; // Reference to the ToppingManager script
    public TextMeshProUGUI popupTextPrefab;
    public Transform popupTextParent;

    private int currentOrderIndex; // Index of the current order being displayed
    private int score; // Player's score
    private float orderTimer; // Timer for the order duration


    public int Score
    {
        get { return score; }
        set { score = value; }
    }

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

        int scoreChange = 0;
        string popupText = "";

        if ((currentOrderIndex == 0 && pearls == 3) ||
            (currentOrderIndex == 1 && pearls == 2 && jelly == 1) ||
            (currentOrderIndex == 2 && jelly == 3))
        {
            scoreChange = 10;
            popupText = "+10";
        }
        else
        {
            scoreChange = -5;
            popupText = "-5";
        }

        score += scoreChange;

        // Show popup text
        ShowPopupText(popupText);

        // Reset topping count regardless of the order outcome
        toppingManager.ResetCounts();

        UpdateScoreText();
        NextOrder();
    }

    // Function to update score text
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Function to show pop-up text
    private void ShowPopupText(string text)
    {
        TextMeshProUGUI popupText = Instantiate(popupTextPrefab, popupTextParent);
        popupText.text = text;

        Destroy(popupText.gameObject, 1f); // Destroy the pop-up text after 1 second
    }

    public void GameEnd()
    {
        // Set the final score in the GameManager
        GameManager.Instance.FinalScore = score;

        // Load the "GameEnd" scene
        SceneManager.LoadScene("GameEnd");
    }
    public void ResetToppingCount()
    {
        toppingManager.ResetCounts();
    }
}