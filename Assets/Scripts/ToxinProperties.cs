using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxinProperties : MonoBehaviour
{
    [SerializeField] float speed = 5;
    VirusSpawner viruscounter;
    [SerializeField] GameObject virus;
    
    void Awake()
    {
        viruscounter = virus.GetComponent<VirusSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        //shoot direction
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Virus")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            viruscounter.viruscount -=  1;
        }
    } 
}
