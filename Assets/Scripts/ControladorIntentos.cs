using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorIntentos : MonoBehaviour {

    [Header("Imagenes botones")]
    public Sprite imagenIntentoOk;
    public Sprite imagenIntentoErroneo;
    [SerializeField] GameObject jugarOtraVez;

    [Header("Intentos")]
    public int cantidadIntentos = 3;
    public GameObject prefabIntentos;

    private GameObject objetoBotonCreado;
    public List<GameObject> listaObjetosBotonesCreados;

    public static int intentoActual = 0;
    private Valija VA;
    private Armario AR;

    private void Awake()
    {
        VA = FindObjectOfType<Valija>();
        AR = FindObjectOfType<Armario>();
        listaObjetosBotonesCreados = new List<GameObject>();

        listaObjetosBotonesCreados.Clear();

        for (int a = 0; a < cantidadIntentos; a++)
        {
            objetoBotonCreado = Instantiate(prefabIntentos);
            objetoBotonCreado.transform.SetParent(transform);
            listaObjetosBotonesCreados.Add(objetoBotonCreado);

        }


    }

    public void RestableceBotones()
    {
        for (int a = 0; a < listaObjetosBotonesCreados.Count ; a++)
        {
            listaObjetosBotonesCreados[a].GetComponent<Image>().sprite = null;
            listaObjetosBotonesCreados[a].GetComponent<Image>().color = Color.clear;
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
           
            AR.CancelaArmario();
            jugarOtraVez.SetActive(true);
        }
       
    }

    
}
