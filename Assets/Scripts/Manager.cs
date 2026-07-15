using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Manager : MonoBehaviour
{

    public static int rondasP1;
    public static int rondasP2;
    public GameObject[] activarRondasP1;
    public GameObject[] activarRondasP2;
    public float time = 3f;

    public GameObject winner1;
    public GameObject winner2;
    public GameObject ko;

    public static int rachaVictoriasP1;
    public static int rachaVictoriasP2;
    public TMP_Text victoriasP1;
    public TMP_Text victoriasP2;
    public GameObject rematch;

    public TMP_Text nameP1;
    public TMP_Text nameP2;

    public Animator animatorP1;
    public Animator animatorP2;
    public string[] victoryPose;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        nameP1.text = PlayerNamesStorage.instance.player1Name;
        nameP2.text = PlayerNamesStorage.instance.player2Name;

        if (rondasP1 > 0) 
        {
            activarRondasP1[rondasP1 - 1].SetActive(true);
        }

        if (rondasP2 > 0)
        {
            activarRondasP2[rondasP2 - 1].SetActive(true);
        }

        // Racha victorias
        rachaVictoriasP1 = PlayerPrefs.GetInt("victoriaP1", 0);
        victoriasP1.text = string.Format("V {0}", rachaVictoriasP1);
        rachaVictoriasP2 = PlayerPrefs.GetInt("victoriaP2", 0);
        victoriasP2.text = string.Format("V {0}", rachaVictoriasP2);
    }

    public void GanarRondaP1()
    {
        rondasP1++;
        
        print("GANA PLAYER 1");
        ko.SetActive(true);
        StartCoroutine(setBoolP1(victoryPose[Random.Range(0, 2)], 0.5f));

        activarRondasP1[rondasP1 - 1].SetActive(true);
        if (rondasP1 >= 2)
        {
            winner1.SetActive(true);
            //StartCoroutine(TerminarPartida());
            Invoke("Revancha", 3f);
            StartCoroutine(setBoolP1(victoryPose[Random.Range(0, 2)], 0.5f));

            // Racha victorias
            rachaVictoriasP2 = 0;
            rachaVictoriasP1++;
            PlayerPrefs.SetInt("victoriaP1", rachaVictoriasP1);
            PlayerPrefs.SetInt("victoriaP2", rachaVictoriasP2);
        }
        else {
            StartCoroutine(ReiniciarEscena());
        }
    }

    public void GanarRondaP2()
    {
        rondasP2++;
        print("GANA PLAYER 2");
        ko.SetActive(true);
        StartCoroutine(setBoolP2(victoryPose[Random.Range(0, 2)], 0.5f));

        activarRondasP2[rondasP2 - 1].SetActive(true);
        if (rondasP2 >= 2)
        {
            winner2.SetActive(true);
            //StartCoroutine(TerminarPartida());
            Invoke("Revancha", 2.5f);
            StartCoroutine(setBoolP2(victoryPose[Random.Range(0, 2)], 0.5f));
            //victore pose
            //se activa letrero de winner P2
            //te vuelva al menu de inicio

            // Racha victorias
            rachaVictoriasP1 = 0;
            rachaVictoriasP2++;
            PlayerPrefs.SetInt("victoriaP1", rachaVictoriasP1);
            PlayerPrefs.SetInt("victoriaP2", rachaVictoriasP2);
        }
        else
        {
            StartCoroutine(ReiniciarEscena());
        }

    }
    public void Revancha()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (rondasP2 >= 2 || rondasP1 >=2) 
        {
            rematch.SetActive(true);        
        }
    }

    public void RevanchaYes()
    {
        rondasP1 = 0;
        rondasP2 = 0;
        SceneManager.LoadScene("JcJ");
    }

    IEnumerator setBoolP1(string name, float time = 0.01f)
    {
        yield return new WaitForSeconds(0.5f);
        animatorP1.SetBool(name, true);
        yield return new WaitForSeconds(time);
        animatorP1.SetBool(name, false);
    }

    IEnumerator setBoolP2(string name, float time = 0.01f)
    {
        yield return new WaitForSeconds(0.5f);
        animatorP2.SetBool(name, true);
        yield return new WaitForSeconds(time);
        animatorP2.SetBool(name, false);
    }

    IEnumerator ReiniciarEscena()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        print("REINICIAR ESCENA");
    }

    IEnumerator TerminarPartida()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("MenuPrincipal");

        print("Partida acabada");
    }
}
