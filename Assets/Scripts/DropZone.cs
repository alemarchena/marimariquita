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
        if (valija == null)
        {
            FindObjectOfType<Valija>().CerrarValija();
        }

        armario = gameObject.GetComponent<Armario>();

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            d.panelDeRetorno = this.transform;

            if (valija != null)
            { //si el objeto fue soltado en la valija
                FindObjectOfType<Valija>().VerificaObjetosColocadosEnValija(eventData.pointerDrag); //envia a la valija el objeto soltado
                FindObjectOfType<Valija>().CerrarValija();
            }

            if (armario != null)
            { //si el objeto fue soltado en el armario
                FindObjectOfType<Armario>().VerificaObjetosColocadosEnArmario(eventData.pointerDrag);
            }

        }
    }
}
