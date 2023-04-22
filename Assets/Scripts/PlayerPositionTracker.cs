using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionTracker : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = Camera.main.WorldToViewportPoint(player.transform.position);
        if(playerPos.x > 1.0f || playerPos.x < 0.0f || playerPos.y > 1.0f || playerPos.y < 0.0f)
        {
            RestartScene();
        }
    }

    void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
