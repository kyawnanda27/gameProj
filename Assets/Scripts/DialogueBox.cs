using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueBox : MonoBehaviour
{
    TMP_Text mText;
    GameObject textBg;

    string[] startDialogue = { 
        "<b>You are a dendritic cell. Dendritic cells patrol the body. ", 
        "<b>When they arrive at the site of an infection, they collect samples of pathogen and bring them to the lymph nodes to look for an appropriate helper T cell. ", 
        "<b>Follow the arrows to find the site of infection. ", 
        "<b>Use the arrow keys to move. "
    };

    string[] scene2 = { 
        "<b>This is a virus", 
        "<b>This virus will not do any damage and is just to show you what they look like. ", 
        "<b>Keep following the arrows to find the site of infection. "
    };

    int dialogueNum;
    // Start is called before the first frame update
    void Start()
    {
        mText = gameObject.GetComponent<TMP_Text>();
        textBg = GameObject.Find("TextBG");
        dialogueNum = 0;
        Time.timeScale = 0;
        next();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next()
    {
        // change the text of the TextMeshPro component
        if (SceneManager.GetActiveScene().name == "StartingScene1") {
            string[] dialoguePack = startDialogue;
            if (dialogueNum == dialoguePack.Length) {
                Time.timeScale = 1;
                Destroy(textBg);
                Destroy(this.gameObject);
            } else {
                mText.text = dialoguePack[dialogueNum];
                dialogueNum += 1;
            }
        } else if (SceneManager.GetActiveScene().name == "StartingScene2") {
            string[] dialoguePack = scene2;
            if (dialogueNum == dialoguePack.Length) {
                Time.timeScale = 1;
                Destroy(textBg);
                Destroy(this.gameObject);
            } else {
                mText.text = dialoguePack[dialogueNum];
                dialogueNum += 1;
            }
        }
    }
}
