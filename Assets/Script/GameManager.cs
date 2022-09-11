using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is calledr before the first frame update
    public GameObject panel;
    public GameObject rain;
    public static GameManager I;
    public Text scoreText;
    public Text timeTxt;
    int totalScore = 0;
    float timeLimit = 30.0f;

    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void addScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        InvokeRepeating("makeRain", 0, 0.5f);
        initGame();
    }

    void initGame()
    {
        Time.timeScale = 1.0f;
        totalScore = 0;
        timeLimit = 30.0f;
    }

    void makeRain()
    {
        Instantiate(rain);
        // Debug.Log("비를 내려라!");
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;
        if (timeLimit < 0)
        {
            Time.timeScale = 0.0f;
            panel.SetActive(true);
            timeLimit = 0.0f;
        }
        timeTxt.text = timeLimit.ToString("N2");
    }
}
