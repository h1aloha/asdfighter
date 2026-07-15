using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kame2 : MonoBehaviour
{
    public float life = 3;
    public float frBlockStun;
    public float frHitStun;

    void Awake()
    {
        Destroy(gameObject, life);
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
            Destroy(gameObject);
        }
        if (other.CompareTag("Kame")) {
            if(other.gameObject != null) Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
