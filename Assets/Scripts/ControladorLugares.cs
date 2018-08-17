using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorLugares : MonoBehaviour {

    public List<Lugar> lugares;
    public List<Sprite> todasImagenesObjetos;
    public int idLugarElegido;

    private void Awake()
    {
        AsignaImagenesLugarBoton();
    }

    private void AsignaImagenesLugarBoton() {
        for (int a = 0;a < lugares.Count ; a++) {
            lugares[a].botonLugar.GetComponent<Image>().sprite = lugares[a].imagenLugar;
        }
    }
}
