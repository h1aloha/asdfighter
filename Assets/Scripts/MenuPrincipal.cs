using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject listaMovimientos;
    public GameObject menuOpciones;
    public GameObject menuAudio;
    public GameObject playerNames;
    public GameObject menuGame;
    public GameObject menuVideo;
    public GameObject pressStart;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        // Reiniciar RONDAS de los jugadores
        
        //Manager.rondasP1 = 0;
        //Manager.rondasP2 = 0;       
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Cerrar();
            CerrarSubMenu();
        }
    }

    public void ModoJuego()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //jcj = modo;
        SceneManager.LoadScene("JcJ");
    }
    
    public void Names()
    {
        playerNames.SetActive(true);
    }

    public void MoveList()
    {
        listaMovimientos.SetActive(true);
    }

    public void Options()
    {
        menuOpciones.SetActive(true);
    }

    public void Audio()
    {
        menuAudio.SetActive(true);
    }

    public void Game()
    {
        menuGame.SetActive(true);
    }

    public void Video()
    {
        menuVideo.SetActive(true);
    }


    public void PressStart()
    {
        pressStart.SetActive(true);
    }

    public void Cerrar()
    {
        listaMovimientos.SetActive(false);
        menuOpciones.SetActive(false);
        playerNames.SetActive(false);
    }

    public void CerrarSubMenu()
    {
        menuAudio.SetActive(false);
        menuGame.SetActive(false);
        menuVideo.SetActive(false);
    }

    public void CerrarJuego()
    {
        Application.Quit();
        print("JUEGO CERRADO");
    }
}
