using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSe : MonoBehaviour
{
    public static NoSe instance;
    private void Start()
    {
        if (instance)
        {
            GameObject nMaster = new GameObject("aaaa");
            nMaster.AddComponent<NoSe>();
            List<GameObject> list = new List<GameObject>();
            foreach (Transform child in instance.gameObject.transform)
            {
                // child.transform.parent = nMaster.transform;
                list.Add(child.gameObject);
            }
            foreach (GameObject child in list)
            {
                child.transform.parent = nMaster.transform;
            }
            Destroy(instance.gameObject);
            instance = null;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    ToggleGOs(false);
        //    instance = this;
        //    GameManager.instance.ChangeScene("Pcdesktop");
        //}
        //else if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    ToggleGOs(true);
        //    GameManager.instance.ChangeScene("HabitaciónNiño");
        //}
    }

    public void ToggleGOs(bool activate)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(activate);
        }

        if (!activate)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
