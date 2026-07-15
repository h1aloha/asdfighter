using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox2 : MonoBehaviour
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
        if (other.CompareTag("Player1"))
        {
            if (other.GetComponent<Player1>())
            {
                other.GetComponent<Player1>().HitOrBlock(frBlockStun, frHitStun);
            }
            else
            {
                other.transform.parent.GetComponent<Player1>().HitOrBlock(frBlockStun, frHitStun);
            }
            print(gameObject.name + " ha golpeado a player1");
        }
    }
}
