using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DendritMovementMenu : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] bool isGrounded = false;
    [SerializeField] int randomizer;
    [SerializeField] float maxY = -10.9f;
    [SerializeField] Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        if(rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        
        if(speed == 0)
            speed = 3;

        randomizer = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(isGrounded)
        {
            if(randomizer % 2 == 0)
            
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            
            else
                transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(transform.position.y <= maxY)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    
}