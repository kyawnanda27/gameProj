using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBG : MonoBehaviour
{
    DialogueBox textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GameObject.Find("TextBox").GetComponent<DialogueBox>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // change the text of the TextMeshPro component
        textBox.next();
    }
}
