using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawner : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] GameObject timer;
    bool hasRun = false;
    float remainingTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasRun)
        {
            remainingTime = timer.GetComponent<Timer>().getRemainingTime();
            if(remainingTime <= 0.0f)
            {
                Spawn();
            }
        }
    }

    void Spawn()
    {
        hasRun = true;
        float xMin = -10.88f;
        float xMax = -1.15f;
        float yMin = -5.97f;
        float yMax = 3.64f;

        Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        Instantiate(door, position, Quaternion.identity);
    }
}
