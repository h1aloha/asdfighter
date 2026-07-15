using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounds : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject timer;

    public GameObject objetoDesactivar;
    public Camera camaraJugador;

    // Start is called before the first frame update
    void Start()
    {
        player1.GetComponent<Player1>().enabled = false;
        player1.GetComponent<Attack1>().enabled = false;

        player2.GetComponent<Player2>().enabled = false;
        player2.GetComponent<Attack2>().enabled = false;

        timer.GetComponent<Temp>().enabled = false;
        //Invoke("ActivarObjetoYCamara", 5f);
    }

    public void ActivarObjetoYCamara()
    {
        player1.GetComponent<Player1>().enabled = true;
        player1.GetComponent<Attack1>().enabled = true;

        player2.GetComponent<Player2>().enabled = true;
        player2.GetComponent<Attack2>().enabled = true;

        timer.GetComponent<Temp>().enabled = true;

        camaraJugador.enabled = true;

        if (objetoDesactivar != null)
        {
            objetoDesactivar.SetActive(false);
        }
    }
}
