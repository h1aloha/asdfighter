using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{
    private Player1 player1;
    public Animator animator;

    public Transform hadoSpawnPoint;
    public GameObject hado;
    public float hadoSpeed = 5f;
    public bool puedeUsarKame = true;
    public GameObject iconKame;

    private void Start()
    {
        player1 = GetComponent<Player1>();
    }

    void Update()
    {
        if (player1.inutil == false)
        {
            Debug.Log("cristu FUNCIONA POR DIOS");
            Ataque();
            Proyectil();
        }

        if (player1.numBlocks <= 0 && puedeUsarKame == true)
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (player1.moveInputHorizontal < 0)
            {
                StartCoroutine(setBool("low"));
                player1.ActivarInutil(17f);

                
            }
            else if (player1.moveInputHorizontal > 0)
            {
                StartCoroutine(setBool("HP"));
                player1.ActivarInutil(22f);
                Debug.Log("FUNCIONAS O QUE OSTIAS PASA");
            }
            else
            {
                StartCoroutine(setBool("medio"));
                player1.ActivarInutil(17f);
            }
        }
    }

    public void Proyectil()
    {
        if (Input.GetKeyDown(KeyCode.H) && player1.numBlocks <= 0 && puedeUsarKame==true)
        {
            StartCoroutine(setBool("hadouken"));
            print(player1.moveInputHorizontal);
            if (player1.moveInputHorizontal == 0) {
                player1.ActivarInutil(25f);
            }
            player1.isBlocking = false;
            puedeUsarKame = false;
            print("hadouken");
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
        yield return new WaitForSeconds (0.1f);
        animator.SetBool(name, false);
    }
}