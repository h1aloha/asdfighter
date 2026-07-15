using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox1 : MonoBehaviour
{

    public AudioSource sonidoGolpe;
    public float frBlockStun;
    public float frHitStun;

    public void Start()
    {
        sonidoGolpe = GetComponent<AudioSource>();
        if (sonidoGolpe == null)
        {
            sonidoGolpe = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player2"))
        {
            if (other.GetComponent<Player2>())
            {
                other.GetComponent<Player2>().HitOrBlock(frBlockStun, frHitStun);

                sonidoGolpe.PlayOneShot(sonidoGolpe.clip);
            }
            else 
            {
                other.transform.parent.GetComponent<Player2>().HitOrBlock(frBlockStun, frHitStun);

                sonidoGolpe.PlayOneShot(sonidoGolpe.clip);
            }
            sonidoGolpe.PlayOneShot(sonidoGolpe.clip);

            print(gameObject.name + " ha golpeado a player2");
        }
    }
}
