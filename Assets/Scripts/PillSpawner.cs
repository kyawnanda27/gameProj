using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PillSpawner : MonoBehaviour
{
    [SerializeField] GameObject pill;
    const float DEFAULT_RATE = 7.0f;
    float levelMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        //float levelMultiplier = (100 - ((SceneManager.GetActiveScene().buildIndex - 5) * 10))/100.0f;
        int scene = SceneManager.GetActiveScene().buildIndex;
        if(scene < 9)
        levelMultiplier = (scene - 5) * 1.3f;

        else
        levelMultiplier = (scene - 9) * 1.3f;
        

        float spawnRate = DEFAULT_RATE + levelMultiplier;
        Debug.Log(spawnRate);
        InvokeRepeating("spawn", 9.0f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
        Vector2 position = new Vector2(Random.Range(-9, 9), Random.Range(-3, 3));
        Instantiate(pill, position, Quaternion.identity);
    }
}
