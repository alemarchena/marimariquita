using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Valija : MonoBehaviour {

    [Header("Imagenes")]
    public Sprite imagenAbiertaConTapa;
    public Sprite imagenAbierta;
    public Sprite imagenCerrada;
    public List<Sprite> imagenesCorrectas;
    public bool valijaAbierta = false;
    public int limiteAciertos = 3;
    public int limiteDesaciertos = 3;
    public int aciertos=0;
    public int desaciertos = 0;

    private Sprite imagenAbiertaActual=null;

    private ControladorLugares CL;
    private GameObject controladorLugares;
    public List<Sprite> imagenesEnValija;

    private void Awake()
    {
        controladorLugares = GameObject.Find("ControladorLugares");
        CL = controladorLugares.GetComponent<ControladorLugares>();

        imagenesEnValija = new List<Sprite>();
        imagenesEnValija.Clear();
        imagenAbiertaActual = imagenAbierta;
    }

    private void Start()
    {
        valijaAbierta = true;
        ReconoceObjetosCorrectos();    
    }

    private void Update()
    {
        if (valijaAbierta)
        {
            ReemplazaImagenValija(imagenAbiertaActual);
        }
        else {
            ReemplazaImagenValija(imagenCerrada);
        }
    }

    public void ReemplazaImagenAbierta(Sprite imagenValijaAbierta)
    {
        imagenAbiertaActual = imagenValijaAbierta;
        ReemplazaImagenValija(imagenAbierta);
    }
    private void ReemplazaImagenValija(Sprite imagenValija)
    {
        GetComponent<Image>().sprite = imagenValija;
    }
    private void ReconoceObjetosCorrectos()
    {
        imagenesCorrectas.Clear();
        //CL.idLugarElegido -1 ya que el idLugar comienza en 1 y el cero es SIN LUGAR
        for (int a=0; a < CL.lugares[CL.idLugarElegido -1].imagenesObjetosCorrectos.Count; a++) { //imagenes que estan correctas en un lugar
            imagenesCorrectas.Add(CL.lugares[CL.idLugarElegido-1].imagenesObjetosCorrectos[a]);                
        }
    }

    public void VerificaObjetosColocadosEnValija(GameObject objetoColocado)
    {
        Debug.Log("Coloco : " + objetoColocado.GetComponent<Image>().sprite.name);
        
        for (int a = 0; a < imagenesCorrectas.Count; a++) {
            //Debug.Log(imagenesCorrectas[a].name + "," + objetoColocado.GetComponent<Image>().sprite.name);

            if (imagenesCorrectas[a].name == objetoColocado.GetComponent<Image>().sprite.name) {
                Debug.Log("ok");


                if (VerificaImagenesEnValija(objetoColocado.GetComponent<Image>().sprite) == false)
                {//si la imagen no estaba en la valija
                    FindObjectOfType<ControladorIntentos>().ActualizaIntento(true);
                }

                FindObjectOfType<Armario>().armarioAbierto = false;//cierra el armario
                Destroy(objetoColocado);
                return;
            }
        }
        Debug.Log("Nop");
        
        FindObjectOfType<ControladorIntentos>().ActualizaIntento(false);//cierra el armario
        FindObjectOfType<Armario>().armarioAbierto = false;
        Destroy(objetoColocado);
    }

    private bool VerificaImagenesEnValija(Sprite imagenLlegada)
    {

        for (int a=0;a<imagenesEnValija.Count;a++)
        { 
            if(imagenLlegada.name == imagenesEnValija[a].name)
            {
                return true; //como esta en la valija no incrementa el intento
            }
            else { 
                imagenesEnValija.Add(imagenLlegada);
                return false;
            }
        }

        if (imagenesEnValija.Count == 0)
            imagenesEnValija.Add(imagenLlegada);
        return false; //devuelve falso para incrementar el intento
    }
}

