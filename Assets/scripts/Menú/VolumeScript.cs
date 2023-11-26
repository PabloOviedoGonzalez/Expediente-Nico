using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    public Slider slider;
    public float slidervalue;
    public Image imagemute;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f); 
        AudioListener.volume = slider.value; 
        VolumeMute();
    }

    public void ChangeSlider(float value)
    {
        slider.value = value;
        PlayerPrefs.SetFloat("VolumeAudio", slidervalue);
        AudioListener.volume = slider.value;
        VolumeMute();
    }

    public void VolumeMute()
    {
        if (slider.value == 0) 
        {
            imagemute.enabled = true;
        }
        else
        {
            imagemute.enabled = false;
        }
    }
  
}
