using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //   gamemanager- un objeto accesible desde cualquier parte de la aplicacion q tiene q estar presente en cualquier escena de la aplicacion a lo largo de todo el juego y
    //tiene esas funciones especificas q no sean parte de otro objeto del juego.Llevar el control de funciones q no sean parte del juego.
    // desde los abjetos se accede al GameManager OK OK OK OK
    //desde el GameManager no se accede a los objetos(porq si tienes esa referencia al cambiar de escena esa referencia se va a destruir y perder) ERROR ERROR ERROR


    public static GameManager instance; //el estatic hace q solo pueda ahber una variable asi en el codigo y el static + el public hace q se pueda llamar desde todo el codigo(singletone)
    //una variable static (estatica) es una variable q solo puede existir una vez por ejecucion de la aplicacion.solo existe una copia en el codigo.y se hace accesible desde cualquier lugar del codigo.

    public AudioClip nombre;
    [Range(0, 1)]
    public float nombreVolume;

   

    private float time = 0;
    // Start is called before the first frame update
    void Awake() // se hace en el awake para q se inicialice lo primero, por si en el start hubiera algo q lo use y lo usase antes de q se iniciase
    {
        if (instance == null)//comprueba si instance no contiene informacion. tambien hace q no se destruya nunca
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //si tiene info, significa q ya existe otro GameManager y destruye este para q no se duplique ya q solo puede haber uno
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        time += Time.deltaTime;

        
    }

    

    public float GetTime()
    {
        return time;
    }

    public void ChangeScene(string name)
    {
        AudioManager.instance.ClearAudioList();
        time = 0;
        SceneManager.LoadScene(name);
        
    }

}
