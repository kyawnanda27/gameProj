using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirusRemainsSpawner : MonoBehaviour
{
    [SerializeField] GameObject virusRemains;
    const float DEFAULT_RATE = 7.0f;
    float levelMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        levelMultiplier = (scene - 5) * 1.3f;

        float spawnRate = DEFAULT_RATE + levelMultiplier;
        Debug.Log(spawnRate);
        InvokeRepeating("Spawn", 5.0f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Vector2 position = new Vector2(Random.Range(-9, 9), Random.Range(-3, 3));
        Instantiate(virusRemains, position, Quaternion.identity);
    }
}
