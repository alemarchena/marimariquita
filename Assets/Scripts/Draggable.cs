using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    [HideInInspector] public Transform panelDeRetorno=null;
    [SerializeField] Transform canvasFalso;

    private void Awake()
    {
        canvasFalso = GameObject.Find("CanvasFalso").transform;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Inicia Drag");

        panelDeRetorno = transform.parent; //guarda el objeto panel padre de la imagen
        //transform.SetParent(transform.parent.parent);
        transform.SetParent(canvasFalso); //emparenta al objeto a un canvas ScreenSpace en vez de Worldspace

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //GameObject.Find("PanelValija").GetComponent<Valija>().ReemplazaImagenAbierta(GameObject.Find("PanelValija").GetComponent<Valija>().imagenAbiertaConTapa);
        GameObject.Find("PanelValija").GetComponent<Valija>().AbrirValija();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Draggeando");
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("Termino Drag");
        transform.SetParent(panelDeRetorno);    
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        
    }
}
