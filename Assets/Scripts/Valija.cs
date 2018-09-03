using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Valija : MonoBehaviour {

    [Header("Animaciones")]
    [SerializeField] Animator anim;
    [Header("Imagenes")]
    public Sprite imagenAbiertaConTapa;
    public Sprite imagenAbierta;
    public Sprite imagenCerrada;
    public List<Sprite> imagenesCorrectas;

    public int limiteAciertos = 3;
    public int limiteDesaciertos = 3;
    public int aciertos=0;
    public int desaciertos = 0;

    [SerializeField] ControladorEfectos CE;

    private ControladorIntentos CI;
    private Armario AR;
    private ControladorLugares CL;
    private GameObject controladorLugares;
    public List<Sprite> imagenesEnValija;
    
    private void Awake()
    {
        controladorLugares = GameObject.Find("ControladorLugares");
        CI = FindObjectOfType<ControladorIntentos>();
        CL = controladorLugares.GetComponent<ControladorLugares>();
        AR = FindObjectOfType<Armario>();

        imagenesEnValija = new List<Sprite>();
        imagenesEnValija.Clear();
    }

    private void Start()
    {
        ReconoceObjetosCorrectos();    
    }

    public void AbrirValija() {
        ReemplazaImagenValija(imagenAbiertaConTapa);
    }

    public void CerrarValija() {
        ReemplazaImagenValija(imagenCerrada);

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
        for (int a = 0; a < imagenesCorrectas.Count; a++) {

            if (imagenesCorrectas[a].name == objetoColocado.GetComponent<Image>().sprite.name) {
                //Debug.Log("ok");

                //if (VerificaImagenesEnValija(objetoColocado.GetComponent<Image>().sprite) == false)
                //{//si la imagen no estaba en la valija
                   
                   CE.MostrarBrilloMariquita();
                    anim.SetTrigger("OK");
                //    Debug.Log("okokok");
                //}

                AR.CierraArmario();//cierra el armario
                CI.ActualizaIntento(true);
                Destroy(objetoColocado);
                return;
            }
        }
        //Debug.Log("Nop");
       
        AR.CierraArmario();
        CI.ActualizaIntento(false);//cierra el armario
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

