using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engulf : MonoBehaviour
{
    VirusSpawner viruscounter;
    [SerializeField] GameObject virus;
    [SerializeField] Text virusCount;
    [SerializeField] Text virusAteCounter;
    float virusAte = 0;
    
    void Awake()
    {
        viruscounter = virus.GetComponent<VirusSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        virusCount.text = "Viruses: " + viruscounter.viruscount;
        virusAteCounter.text = "Viruses Ate: " + virusAte + " / 15";
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Virus")
        {
            Destroy(collision.gameObject);
            viruscounter.viruscount -=  1;
            if(allowVirus()){
                virusAte++;
                
                PersistentData.Instance.SetScore(PersistentData.Instance.GetScore()+ 10);
            }
            //else{}
            
            
        }
    } 

    public bool allowVirus()
    {
        if(virusAte <= 15)
            return true;
        else 
            return false;
    }
}
