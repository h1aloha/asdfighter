using System.Collections;
using UnityEngine;


public class Attack2 : MonoBehaviour
{
    private Player2 player2;
    public Animator animator;

    public Transform hadoSpawnPoint;
    public GameObject hado;
    public float hadoSpeed = 5f;
    public bool puedeUsarKame = true;
    public GameObject iconKame;

    private void Start()
    {
        player2 = GetComponent<Player2>();
    }

    void Update()
    {
        if (player2.inutil == false)
        {
            Ataque();
            Proyectil();
        }

        if (player2.numBlocks <= 0 && puedeUsarKame == true)
        {
            iconKame.SetActive(true);
        }
        else
        {
            iconKame.SetActive(false);
        }
    }

    public void Ataque()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (player2.moveInputHorizontal2 > 0)
            {
                StartCoroutine(setBool("low"));
                player2.ActivarInutil(17f);

                Debug.Log("te pego!!");
            }
            else if (player2.moveInputHorizontal2 < 0)
            {
                StartCoroutine(setBool("HP"));
                player2.ActivarInutil(22f);
            }
            else
            {
                StartCoroutine(setBool("medio"));
                player2.ActivarInutil(17f);
            }
        }
    }

    public void Proyectil()
    {
        if (Input.GetKeyDown(KeyCode.Keypad3) && player2.numBlocks <= 0 && puedeUsarKame == true)
        {
            StartCoroutine(setBool("hadouken"));
            print(player2.moveInputHorizontal2);
            if (player2.moveInputHorizontal2 == 0)
            {
                player2.ActivarInutil(25f);
            }
            player2.isBlocking = false;
            puedeUsarKame = false;
            print("hadouken2");
        }
    }

    public void CrearKame()
    {
        var kame = Instantiate(hado, hadoSpawnPoint.position, hadoSpawnPoint.rotation);
        kame.GetComponent<Rigidbody2D>().velocity = hadoSpawnPoint.right * hadoSpeed;
    }

    IEnumerator setBool(string name)
    {
        animator.SetBool(name, true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool(name, false);
    }
}
