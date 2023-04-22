using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] InputField playerNameInput;
    [SerializeField] GameObject[] pauseMode;
    [SerializeField] GameObject[] resumeMode;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject button in resumeMode)
        {
            button.SetActive(true);
        }
        foreach(GameObject button in pauseMode)
        {
            button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorblindMode()
    {
        SceneManager.LoadScene("cblevel1");
    }

    public void PlayGame()
    {
        string s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("StartingScene1");
    }

    public void ToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToSetting()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ToHighScore()
    {
        SceneManager.LoadScene("highscores");
    }

    public void ToNextLevel()
    {
        int currentLevel = PersistentData.Instance.GetCurrentLevel();
        SceneManager.LoadScene(currentLevel + 1);
    }

    public void ToLevel1() {
        SceneManager.LoadScene("level1");
    }

    public void ToLevel2() {
        SceneManager.LoadScene("level2");
    }

    public void ToLevel3() {
        SceneManager.LoadScene("level3");
    }

    public void SaveChange()
    {
        /*float vol = PersistentData.Instance.GetVolume();
        
        PersistentData.Instance.SetVolume(vol);
        PersistentData.Instance.Set*/
        AudioListener.volume = PersistentData.Instance.GetVolume() / 10;
        PersistentData.Instance.tempToMain();
    }
    
    public void PauseGame() 
    {
        Time.timeScale = 0;
        foreach(GameObject button in pauseMode)
        {
            button.SetActive(true);
        }
        foreach(GameObject button in resumeMode)
        {
            button.SetActive(false);
        }
    }

    public void ResumeGame() 
    {
        Time.timeScale = 1;
        foreach(GameObject button in resumeMode)
        {
            button.SetActive(true);
        }
        foreach(GameObject button in pauseMode)
        {
            button.SetActive(false);
        }
    }

    public void TryAgain()
    {
        int currentLevel = PersistentData.Instance.GetCurrentLevel();
        SceneManager.LoadScene(currentLevel);
        
    }
}
