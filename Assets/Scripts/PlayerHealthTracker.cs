using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthTracker : MonoBehaviour
{
    [SerializeField] int playerHealth;
    [SerializeField] Text playerHealthText;
    [SerializeField] GameObject macrophage;
    Engulf engulf;

    AudioSource aSrc;
    const int score = 10;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 1;
        playerHealthText.text = "Health: " + playerHealth.ToString();

        /*if(SceneManager.GetActiveScene().buildIndex - 4 == 2)
            macrophage = GameObject.FindWithTag("macrophage");
        else
            macrophage = null;*/
        
        aSrc = GetComponent<AudioSource>();
        engulf = macrophage.GetComponent<Engulf>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth == 0)
        {
            TryAgainScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        print("collider");
        if(collider.gameObject.tag == "Virus")
        {

            //SceneManager.LoadScene("battle");
            aSrc.Play();

            if(SceneManager.GetActiveScene().buildIndex == 8)
            {
                if(!engulf.allowVirus()){
                    
                    deduceHealthPoint();}
            }
            else
                deduceHealthPoint();
            playerHealthText.text = "Health: " + playerHealth.ToString();
        }
        if(collider.gameObject.tag == "pill" || collider.gameObject.tag == "VirusRemains")
        {
            if(playerHealth < 3)
                playerHealth += 1;
            else
                {PersistentData.Instance.SetScore(PersistentData.Instance.GetScore()+ score);
                
                }
            //Destroy pill
            Destroy(collider.gameObject);
            playerHealthText.text = "Health: " + playerHealth.ToString();
        }
    }

    void TryAgainScene() 
    {
        SceneManager.LoadScene("TryAgain");
    }

    public void deduceHealthPoint()
    {
        playerHealth -= 1;
    }
}
