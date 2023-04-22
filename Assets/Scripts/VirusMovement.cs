using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirusMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float currentDirectionX;
    [SerializeField] float currentDirectionY;
    [SerializeField] GameObject mainCamera;
    new Camera camera;
    const float minValue = -1.0f;
    const float maxValue = 1.0f;
    const float midValue = 0.0f;
    int levelMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        //level multiplier in speed. Have to change value when there's a change in build settings
        int scene = SceneManager.GetActiveScene().buildIndex;
        levelMultiplier = scene - 4;
        
        if(speed == 0)
            speed = (float) 1.5 * levelMultiplier;
        
        camera = mainCamera.GetComponent<Camera>();
        currentDirectionX = Random.Range(minValue, maxValue);
        currentDirectionY = Random.Range(minValue, maxValue);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 virusPos = camera.WorldToViewportPoint(gameObject.transform.position);
        // When GameObject runs into the edge of camera, change direction
        if(virusPos.x > maxValue) 
        {
            currentDirectionX = Random.Range(minValue, midValue);
            currentDirectionY = Random.Range(minValue, maxValue);
        }
        else if(virusPos.x < midValue)
        {
            currentDirectionX = Random.Range(midValue, maxValue);
            currentDirectionY = Random.Range(minValue, maxValue);
        }
        else if(virusPos.y > maxValue)
        {
            currentDirectionX = Random.Range(minValue, maxValue);
            currentDirectionY = Random.Range(minValue, midValue);
        }
        else if(virusPos.y < midValue)
        {
            currentDirectionX = Random.Range(minValue, maxValue);
            currentDirectionY = Random.Range(midValue, maxValue);
        }
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(currentDirectionX*speed, currentDirectionY*speed, 0) * Time.deltaTime;
    }
}
