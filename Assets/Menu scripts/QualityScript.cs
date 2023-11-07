using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QualityScript : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int Quality;

    private void Start()
    {
        Quality = PlayerPrefs.GetInt("numberofquality", 3);
        dropdown.value = Quality;
        AjustQuality();
    }

    public void AjustQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numberofquality", dropdown.value);
        Quality = dropdown.value;
    }
}
