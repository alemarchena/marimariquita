using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorIntentos : MonoBehaviour {

    [Header("Imagenes botones")]
    public Sprite imagenIntentoOk;
    public Sprite imagenIntentoErroneo;


    [Header("Intentos")]
    public int cantidadIntentos = 3;
    public GameObject prefabIntentos;

    private GameObject objetoBotonCreado;
    private List<GameObject> listaObjetosBotonesCreados;
    private static int intentoActual = 0;

    private void Awake()
    {
        listaObjetosBotonesCreados = new List<GameObject>();
        listaObjetosBotonesCreados.Clear();

        for (int a = 0; a < cantidadIntentos; a++) {
            objetoBotonCreado = Instantiate(prefabIntentos);
            objetoBotonCreado.transform.SetParent(transform);
            listaObjetosBotonesCreados.Add(objetoBotonCreado);
        }
    }

    private void Start()
    {
        intentoActual = 0;
    }

    public static int ValorIntento
    {
        get
        {
            return intentoActual;
        }
        set
        {
            intentoActual = value;
        }
    }

    public void ActualizaIntento(bool Correcto) {
        ValorIntento += 1;
        if (Correcto){
            listaObjetosBotonesCreados[intentoActual - 1].GetComponent<Image>().sprite = imagenIntentoOk;
            listaObjetosBotonesCreados[intentoActual - 1].GetComponent<Image>().color = Color.white; //le cambia la gama para que no sea transparente
        }
        else {
            listaObjetosBotonesCreados[intentoActual - 1].GetComponent<Image>().sprite = imagenIntentoErroneo;
            listaObjetosBotonesCreados[intentoActual - 1].GetComponent<Image>().color = Color.white;

        }
        if (ValorIntento >= cantidadIntentos) {
            FindObjectOfType<Valija>().valijaAbierta = false;
        }
    }

    
}
