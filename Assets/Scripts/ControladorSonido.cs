using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonido : MonoBehaviour {

    public AudioSource audioGeneral;
    public AudioSource audioBotones;

    public float volumenGeneral = 0.5f;
    public float volumenBotones = 0.5f;

    public void PlaySonido()
    {
        audioGeneral.GetComponent<AudioSource>().Play();
    }

    public void StopSonido()
    {
        audioGeneral.GetComponent<AudioSource>().Stop();
    }

    public void HabilitacionDeSonido(bool habilitacion)
    {
        if (habilitacion == true)
        {
            PlaySonido();
            audioBotones.enabled = true;
        }
        else {
            StopSonido();
            audioBotones.enabled = false;
        }
    }

    
}
