
using UnityEngine;
using UnityEngine.UI;

public class ImagenLugar : MonoBehaviour {

    private GameObject CL;
    private ControladorLugares controladorLugares;

    private void Awake()
    {
        CL = GameObject.Find("ControladorLugares");
        controladorLugares = CL.GetComponent<ControladorLugares>();
    }

    private void Start()
    {
        AsignaImagenLugar();
    }

    public void AsignaImagenLugar()
    {
        GetComponent<Image>().sprite = controladorLugares.lugares[controladorLugares.idLugarElegido - 1].imagenLugar;
    }
}
