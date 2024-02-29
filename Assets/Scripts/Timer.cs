using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI element
    public float totalTime = 60f; // Total time for the countdown
    public float animationDuration = 2f; // Duration of the animation

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private Vector3 initialScale;
    private Vector3 targetScale;
    private float currentTime; // Current time left
    private bool isAnimating = true; // Flag to indicate if animation is in progress

    void Start()
    {
        StartCoroutine(AnimateTimer());
    }

    void Update()
    {
        if (!isAnimating)
        {
            // Update the timer only after animation is completed
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;

                // Ensure timer never goes below 0
                if (currentTime < 0)
                {
                    currentTime = 0;
                    // Game Over logic can be placed here
                    Debug.Log("Game Over!"); // Placeholder for Game Over logic
                }

                // Update the UI text
                UpdateTimerText();
            }
        }
    }

    void UpdateTimerText()
    {
        // Format the time in minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        // Update the UI text to display the timer
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator AnimateTimer()
    {
        // Freeze everything in the background
        Time.timeScale = 0f;

        // Save initial position and scale
        initialPosition = timerText.rectTransform.localPosition;
        initialScale = timerText.rectTransform.localScale;

        // Calculate target position and scale
        targetPosition = initialPosition + new Vector3(0f, 200f, 0f); // Move up
        targetScale = initialScale * 0.5f; // Scale down to half

        // Animation loop
        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            // Calculate progress
            float t = elapsedTime / animationDuration;

            // Lerp position and scale
            timerText.rectTransform.localPosition = Vector3.Lerp(initialPosition, targetPosition, t);
            timerText.rectTransform.localScale = Vector3.Lerp(initialScale, targetScale, t);

            // Increment time
            elapsedTime += Time.unscaledDeltaTime;

            yield return null;
        }

        // Set final position and scale
        timerText.rectTransform.localPosition = targetPosition;
        timerText.rectTransform.localScale = targetScale;

        // Start the timer after animation is completed
        currentTime = totalTime;

        // Unfreeze everything in the background
        Time.timeScale = 1f;
        isAnimating = false;
    }
}
