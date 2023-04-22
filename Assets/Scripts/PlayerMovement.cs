using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;

    private Rigidbody2D body;
    private Animator anim;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Vertical") * speed;
        body.velocity = transform.up * movement;
        
        if (!Mathf.Approximately(movement, 0)) // floats aren't always exact, so compare using Approximately()
        {
            
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate the sprite about the Z axis in the positive direction
            transform.Rotate(new Vector3(0, 0, 50) * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate the sprite about the Z axis in the negative direction
            transform.Rotate(new Vector3(0, 0, -50) * Time.deltaTime * speed, Space.World);
        }
        
        anim.SetFloat("speed", Mathf.Abs(movement));
        if (movement < 0) {
            spriteRenderer.flipX = true;
            spriteRenderer.flipY = true;
        } else if (movement > 0) {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
        }

    }
}
