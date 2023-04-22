using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirusSpawner : MonoBehaviour
{
    [SerializeField] GameObject virus;
    [SerializeField] float ySpawnLoc;
    [SerializeField] float xSpawnLoc;
    public int viruscount;
    const float xMin = -11f;
    const float xMax = 11f;
    const float yMin =  -5.9f;
    const float yMax =  5.9f;
    const float DEFAULT_RATE = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        char diffChar = PersistentData.Instance.GetDiff();
        float spawnRate = DEFAULT_RATE;
        //int diffMultiplier = 1
        switch(diffChar)
        {
            case 'e':
                spawnRate = DEFAULT_RATE;
                break;
            
            case 'm':
                spawnRate = DEFAULT_RATE - 0.5f;
                break;

            case 'h':
                spawnRate = DEFAULT_RATE - 1.5f;
                break;
            
        }

        InvokeRepeating("Spawn" , 1.0f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(1, 3) == 1)
            ySpawnLoc = yMin;
        else
            ySpawnLoc = yMax;
        
        if(Random.Range(1, 3) == 1)
            xSpawnLoc = xMin;
        else
            xSpawnLoc = xMax;
        
        if(viruscount > 21)
        {
            SceneManager.LoadScene("TryAgain");
        }
    }

    void Spawn()
    {
        Vector2 position = new Vector2(Random.Range(xMin, xMax), ySpawnLoc);
        Instantiate(virus, position, Quaternion.identity);
        viruscount++;

        Vector2 position2 = new Vector2(xSpawnLoc, Random.Range(yMin, yMax));
        Instantiate(virus, position2, Quaternion.identity);
        viruscount++;
    }
}
