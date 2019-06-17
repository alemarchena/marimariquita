
using UnityEngine;
using UnityEngine.UI;

public class TraspasoNivel : MonoBehaviour {
    public int idLugarElegido;
    [SerializeField] GameObject jugarDeNuevo;

    private GameObject CE;
    private ControladorEscenas controladorEscenas;

    private GameObject CL;
    private ControladorLugares controladorLugares;

    private Armario AR;

    private ControladorIntentos CI;
    
    private void Awake()
    {
        CE = GameObject.Find("ControladorEscenas");
        controladorEscenas = CE.GetComponent<ControladorEscenas>();

        CL = GameObject.Find("ControladorLugares");
        controladorLugares = CL.GetComponent<ControladorLugares>();

        AR = FindObjectOfType<Armario>();

        CI = FindObjectOfType<ControladorIntentos>();
    }

    public void CargarEscena(int indice){
        controladorEscenas.CargarEscena(controladorEscenas.nombresEscenas[indice]);
    }

    public void CargarLugar(int idLugar) {
        idLugarElegido = idLugar;
        controladorLugares.idLugarElegido = idLugar;
    }

    public void JugarDeNuevo()
    {
        jugarDeNuevo.SetActive(false);
        AR.HabilitarArmario();
        ControladorIntentos.intentoActual = 0;
        CI.RestableceBotones();


    }
    
}



   

    

