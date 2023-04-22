using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] public float remainingTime = 60.0f;
    [SerializeField] Text timerText;
    [SerializeField] Text nameText;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject levelComplete;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject pause;
    string playerName;
    int score;

    void Awake()
    {
        PersistentData.Instance.SetCurrentLevel();
    }
    // Start is called before the first frame update
    void Start()
    {
        levelComplete.SetActive(false);
        playerName = PersistentData.Instance.GetName();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        score = PersistentData.Instance.GetScore();
        nameText.text = "Welcome: " + playerName;
        scoreText.text = "Score: " + score;
        timerText.text = "Time remaining: " + ((int)remainingTime).ToString();
        if(remainingTime >= 0.0f)
        {
            remainingTime -= Time.deltaTime;
            //Time.timeScale = 0;
            //displayLevelComplete();
        }
    }

    void displayLevelComplete() {
        levelComplete.SetActive(true);
        mainMenu.SetActive(true);
        pause.SetActive(false);
    }

    public float getRemainingTime()
    {
        return remainingTime;
    }
}
