using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneradorObjetosDraggables : MonoBehaviour {

    public GameObject prefabDraggable;
    [HideInInspector] public GameObject objetoAleatorio=null;
    [HideInInspector] public GameObject objetoAleatorioCreado=null;
    public GameObject PanelPadreObjeto;

    private int tipoObjetoAleatorio;
    private GameObject controladorLugares;
    private ControladorLugares CL;
    private Armario AR;


    private void Awake()
    {
        controladorLugares = GameObject.Find("ControladorLugares");
        CL = controladorLugares.GetComponent<ControladorLugares>();
        AR = FindObjectOfType<Armario>();
    }

    public void CreaObjetoDraggable()
    {
        

        if (CL.todasImagenesObjetos.Count > 0)
        {
            AR.AbreArmario();
            

            if (objetoAleatorioCreado != null)
                Destroy(objetoAleatorioCreado);

            objetoAleatorio = Instantiate(prefabDraggable);//instancia una imagen de la lista de objetos posibles
            objetoAleatorioCreado = objetoAleatorio;
            objetoAleatorioCreado.GetComponent<Image>().sprite = CL.todasImagenesObjetos[Random.Range(0, CL.todasImagenesObjetos.Count)];
            objetoAleatorioCreado.transform.SetParent(PanelPadreObjeto.transform);
            objetoAleatorioCreado.transform.SetPositionAndRotation(PanelPadreObjeto.transform.position, PanelPadreObjeto.transform.rotation);
           
        }
        else {
            Debug.Log("No hay imagenes para crear");
        }
    }
}
