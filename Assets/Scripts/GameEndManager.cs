using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEndManager : MonoBehaviour
{
    public TMP_Text finalScoreText;

    void Start()
    {
        // Display the final score
        finalScoreText.text = "Final Score: " + GameManager.Instance.FinalScore.ToString();
    }
}
