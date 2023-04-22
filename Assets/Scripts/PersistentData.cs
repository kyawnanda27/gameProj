using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] float volValue;
    [SerializeField] char diffChar; 
    [SerializeField] float tempVol;
    [SerializeField] char tempDiff;
    [SerializeField] int currentLevel;
    // Start is called before the first frame update
    public static PersistentData Instance;

    public void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        playerName = "";
        playerScore = 0;
        volValue = 10.0f; //not sure about the AudioListener would change volume for all scenes.
        diffChar = 'e';
        tempVol = 10.0f;
        tempDiff = 'e';
        currentLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public void SetScore(int score)
    {
        playerScore = score;
    }

    public void SetVolume(float vol)
    {
        volValue = vol;
    }
    public void SetTempVolume(float vol)
    {
        tempVol = vol;
    }

    public void SetDiff(char diff)
    {
        diffChar = diff;
    }

    public void SetTempDiff(char diff)
    {
        tempDiff = diff;
    }

    public void SetCurrentLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    public void tempToMain()
    {
        volValue = tempVol;
        diffChar = tempDiff;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public float GetVolume()
    {
        return volValue;
    }

    public float GetTempVolume()
    {
        return tempVol;
    }

    public char GetDiff()
    {
        return diffChar;
    }

    public char GetTempDiff()
    {
        return tempDiff;
    }
    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}
