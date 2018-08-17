using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour,  IDropHandler
{
    private Valija valija;
    private Armario armario;

    
    
    public void OnDrop(PointerEventData eventData)
    {
        valija = gameObject.GetComponent<Valija>();
        if (valija != null) {
            if (valija.valijaAbierta == false) { 
                return;
            }
        }

        armario = gameObject.GetComponent<Armario>();


        //Debug.Log(eventData.pointerDrag.name + "Hizo el Drag en " + gameObject.name);
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            d.panelDeRetorno = this.transform;

            if (valija != null)
            { //si el objeto fue soltado en la valija
                GameObject.FindObjectOfType<Valija>().VerificaObjetosColocadosEnValija(eventData.pointerDrag); //envia a la valija el objeto soltado
                GameObject.Find("PanelValija").GetComponent<Valija>().ReemplazaImagenAbierta(GameObject.Find("PanelValija").GetComponent<Valija>().imagenAbierta);
            }

            if (armario != null)
            { //si el objeto fue soltado en el armario
                GameObject.FindObjectOfType<Armario>().VerificaObjetosColocadosEnArmario(eventData.pointerDrag);
            }

        }
    }
}
