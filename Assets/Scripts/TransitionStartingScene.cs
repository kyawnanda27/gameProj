using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionStartingScene : MonoBehaviour
{
    [SerializeField] GameObject player;

    ButtonFunctions bf;
    // Start is called before the first frame update
    void Start()
    {
        bf = gameObject.GetComponent<ButtonFunctions>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.WorldToViewportPoint(player.transform.position).x >= .98f)
        {
            NextStartingScene();
        }
    }

    void NextStartingScene()
    {
        if (SceneManager.GetActiveScene().name == "StartingScene1") {
            SceneManager.LoadScene("StartingScene2");
        } else if (SceneManager.GetActiveScene().name == "StartingScene2") {
            SceneManager.LoadScene("introlevel1");
        }
    }
}
