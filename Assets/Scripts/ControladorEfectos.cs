using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEfectos : MonoBehaviour {

    [SerializeField] GameObject efectobrilloMariquita;
    [SerializeField] GameObject efectoMovimientos;
    [SerializeField] GameObject efectobrilloAbrir;

    //public bool mariquita = false;
    //public bool movimiento = false;
    //public bool abrir = false;

    public void MostrarBrilloMariquita()
    {
        efectobrilloMariquita.SetActive(true);
        StartCoroutine(Nobrillar());
    }

    IEnumerator Nobrillar()
    {
        yield return new WaitForSeconds(3f);
        efectobrilloMariquita.SetActive(false);
    }

    //movimientos que indican como mover el objeto hacia la mochila o el ropero
    public void MostrarMovimientos()
    {
        efectoMovimientos.SetActive(true);
    }
    public void DetenerMovimientos()
    {
        efectoMovimientos.SetActive(false);
    }
    //muestra el brillo para abrir el ropero
    public void MostrarAbrir()
    {
        efectobrilloAbrir.SetActive(true);
    }
    public void DetenerAbrir()
    {
        efectobrilloAbrir.SetActive(false);
    }
}


