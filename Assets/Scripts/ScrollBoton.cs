using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBoton : MonoBehaviour {

    [SerializeField] RectTransform contenido;
    [SerializeField] float factorDesplazamiento = 10;
    private Vector3 vector = Vector3.zero;
    /// <summary>
    /// Sentido 0 = izquierda, sentido 1 = derecha
    /// </summary>
    /// <param name="sentido"></param>
    public void MoverContenido(int sentido) {
        
        if (sentido == 0)
            vector = new Vector3(contenido.transform.position.x + factorDesplazamiento, contenido.transform.position.y, contenido.transform.position.z);
        if (sentido == 1)
            vector = new Vector3(contenido.transform.position.x - factorDesplazamiento, contenido.transform.position.y, contenido.transform.position.z);

        contenido.transform.position = vector;
    }


}
