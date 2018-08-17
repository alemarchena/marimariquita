using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscenas : MonoBehaviour {

    public static ControladorEscenas CE;

    public string[] nombresEscenas;
    public int indiceEscena=0;

    private void Awake()
    {
        if (CE == null){
            CE = this;
            DontDestroyOnLoad(gameObject);
        }else
            Destroy(gameObject);
    }

    void Start (){
        indiceEscena = 0;
	}

    public void CargarEscena(string nombreEscena){
        SceneManager.LoadScene(nombreEscena);
    }

    public void CargarNivel(int indice)
    {
        indiceEscena = indice;
        CargarEscena(nombresEscenas[indice]);
    }

    public void ResetearJuego(){
        indiceEscena = 0;
    }
}
