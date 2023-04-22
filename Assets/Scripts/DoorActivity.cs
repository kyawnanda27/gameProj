using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorActivity : MonoBehaviour
{
    //[SerializeField] GameObject
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("LevelComplete");
        }
        if(collider.gameObject.CompareTag("macrophage"))
        {
            SceneManager.LoadScene("LevelComplete");
        }
    }

}
