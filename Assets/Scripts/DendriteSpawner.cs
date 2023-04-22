using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DendriteSpawner : MonoBehaviour
{
    [SerializeField] GameObject dendrit;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn" , 0.1f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void Spawn()
    {
        float xMin = -9.17f;
        float xMax = 9.77f;
        float yDir = 8.89f;

        Vector2 position = new Vector2(Random.Range(xMin, xMax), yDir);

        Instantiate(dendrit, position, Quaternion.identity);
    }
}