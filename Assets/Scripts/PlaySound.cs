using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioSource clickBoton;
    public AudioSource overBoton;

    public void ClickOnButton()
    {
        clickBoton.Play();
    }

    public void EnterOnButton()
    {
        overBoton.Play();
    }

}
