
using UnityEngine;
using UnityEngine.UI;

public class TraspasoNivel : MonoBehaviour {
    public int idLugarElegido;
    

    private GameObject CE;
    private ControladorEscenas controladorEscenas;

    private GameObject CL;
    private ControladorLugares controladorLugares;

    private void Awake(){
        CE = GameObject.Find("ControladorEscenas");
        controladorEscenas = CE.GetComponent<ControladorEscenas>();

        CL = GameObject.Find("ControladorLugares");
        controladorLugares = CL.GetComponent<ControladorLugares>();
    }

    public void CargarEscena(int indice){
        controladorEscenas.CargarEscena(controladorEscenas.nombresEscenas[indice]);
    }

    public void CargarLugar(int idLugar) {
        idLugarElegido = idLugar;
        controladorLugares.idLugarElegido = idLugar;
    }

    
}



   

    

