using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private int finalScore;

    public int FinalScore
    {
        get { return finalScore; }
        set { finalScore = value; }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}