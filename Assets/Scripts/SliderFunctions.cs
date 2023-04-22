using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFunctions : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider diffSlider;
    [SerializeField] float volVal;
    [SerializeField] float diffVal;
    [SerializeField] Text volTxt;
    [SerializeField] Text diffTxt;
    [SerializeField] char diffChar;

    // Start is called before the first frame update
    void Awake()
    {
        volumeSlider.value = PersistentData.Instance.GetVolume();
        diffChar = PersistentData.Instance.GetDiff();
        
        if(diffChar == 'e')
            diffSlider.value = 0.0f;
        else if(diffChar == 'm')
            diffSlider.value = 1.0f;
        else
            diffSlider.value = 2.0f;
        //diffSlider.value = PersistentData.Instance.GetDiff();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        volTxt.text = "" + volumeSlider.value;
        diffTxt.text = "" + diffChar;
        
    }

    public void resetSlider()
    {
        volumeSlider.value = 10.0f;
        diffSlider.value = 0.0f;
        changeVolume();
        changeDifficulty();
    }

    public void changeVolume()
    {
        volVal = volumeSlider.value;
        PersistentData.Instance.SetTempVolume(volVal);
    }

    public void changeDifficulty()
    {
        
        diffVal = diffSlider.value;
        /*
        e = easy, m = medium, h = hard
        */
        if(diffVal == 0.0f)
            diffChar = 'e';
        else if(diffVal == 1.0f)
            diffChar = 'm';
        else
            diffChar = 'h';
        
        PersistentData.Instance.SetTempDiff(diffChar);
        //PersistentData.Instance.set
    }
}
