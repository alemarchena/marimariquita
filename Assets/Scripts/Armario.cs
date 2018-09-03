using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armario : MonoBehaviour {

    [SerializeField] ControladorEfectos CE;
    [Header("Imagenes")]
    public Sprite imagenAbierta;
    public Sprite imagenCerrada;
    //public bool armarioAbierto = false;
    [SerializeField] GameObject botonAbrir;
    private void Start()
    {
        CierraArmario();
    }
    public void VerificaObjetosColocadosEnArmario(GameObject objetoColocado)
    {
        //armarioAbierto = false;//cierra el armario
        CierraArmario();
        Destroy(objetoColocado);
    }

    public void AbreArmario() {

        GetComponent<Image>().sprite = imagenAbierta;
        CE.DetenerAbrir();
        botonAbrir.SetActive(false);
        CE.MostrarMovimientos(); //efectos de como debe moverse el objeto que salio del ropero
    }

    public void CierraArmario() {
        GetComponent<Image>().sprite = imagenCerrada;
        CE.MostrarAbrir();
        botonAbrir.SetActive(true);
        CE.DetenerMovimientos();
    }

    public void CancelaArmario() {
        GetComponent<Image>().sprite = imagenCerrada;
        botonAbrir.SetActive(false);
        CE.DetenerMovimientos();
        CE.DetenerAbrir();
    }


}
