using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.Networking.UnityWebRequest;
using System;
using UnityEngine.UIElements;

public class ResolutionScript : MonoBehaviour
{
    public TMP_Dropdown resolutiondropdown;
    Resolution[] resolutions;
    Resolution[] aux;

    public void Start()
    {
        CheckResolution();
    }

    public void CheckResolution()
    {
        resolutions = Screen.resolutions;
        aux = new Resolution[resolutions.Length - 12];
        Array.Copy(resolutions, 12, aux, 0, aux.Length);
        resolutiondropdown.ClearOptions();
        List<string> options = new List<string>();
        int actualresolution = 0;

        for (int i = 0; i < aux.Length; i++)
        {
            string option = aux[i].width + "x" + aux[i].height;
            options.Add(option);

            if (Screen.fullScreen && aux[i].width == Screen.currentResolution.width &&
                aux[i].height == Screen.currentResolution.height)
            {
                actualresolution = i;
            }
        }

        resolutiondropdown.AddOptions(options);
        resolutiondropdown.value = actualresolution;
        resolutiondropdown.RefreshShownValue();

        resolutiondropdown.value = PlayerPrefs.GetInt("numberresolution", 0);
    }

    public void Changeresolution(int indResolution)
    {
        PlayerPrefs.SetInt("numberresolution", resolutiondropdown.value);

        Resolution resolution = aux[indResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
