using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasResolution: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Acceder al componente RectTransform del Canvas
        RectTransform canvasRect = GetComponent<RectTransform>();

        // Establecer el tama�o en p�xeles
        canvasRect.sizeDelta = new Vector2(639, 479);
    }

    // Update is called once per frame
    void Update()
    {
        // Puedes agregar c�digo de actualizaci�n si es necesario
    }
}