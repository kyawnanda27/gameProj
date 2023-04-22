using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text scoreText;
    void Start()
    {
        scoreText.text = "Current Score is " + PersistentData.Instance.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
