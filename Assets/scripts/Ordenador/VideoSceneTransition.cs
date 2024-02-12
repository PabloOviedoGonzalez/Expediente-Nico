using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneTransition : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Asignar el evento cuando el video termine
        videoPlayer.loopPointReached += OnVideoFinished;

        // Reproducir el video al inicio
        PlayVideo();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Cambiar a la siguiente escena cuando el video termine
        SceneManager.LoadScene("Pcpasssword");
    }

    void PlayVideo()
    {
        // Iniciar la reproducción del video
        videoPlayer.Play();
    }
}
