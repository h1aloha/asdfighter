using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject cajaPausa;
    public GameObject moveList;
    bool juegoPausa = false;

    public GameObject player1, player2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausa)
            {
                Reanudar();
                CerrarSubMenu();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        juegoPausa = true;

        Time.timeScale = 0f;
        cajaPausa.SetActive(true);

        player1.GetComponent<Animator>().enabled = false;
        player2.GetComponent<Animator>().enabled = false;
    }

    public void Reanudar()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        juegoPausa = false;

        Time.timeScale = 1f;
        cajaPausa.SetActive(false);

        player1.GetComponent<Animator>().enabled = true;
        player2.GetComponent<Animator>().enabled = true;
    }

    public void MoveList()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        juegoPausa = true;

        Time.timeScale = 0f;
        moveList.SetActive(true);

        player1.GetComponent<Animator>().enabled = false;
        player2.GetComponent<Animator>().enabled = false;
    }

    public void CerrarSubMenu()
    {
        moveList.SetActive(false);
    }


    public void Cerrar(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
        Time.timeScale = 1f;
    }
}
