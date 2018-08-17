using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armario : MonoBehaviour {

    [Header("Imagenes")]
    public Sprite imagenAbierta;
    public Sprite imagenCerrada;
    public bool armarioAbierto = false;

    public void VerificaObjetosColocadosEnArmario(GameObject objetoColocado)
    {
        armarioAbierto = false;//cierra el armario
        Destroy(objetoColocado);
    }
    private void Update()
    {
        if (armarioAbierto)
        {
            GetComponent<Image>().sprite = imagenAbierta;
        }
        else
        {
            GetComponent<Image>().sprite = imagenCerrada;
        }
    }
}
