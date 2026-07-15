using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kame1 : MonoBehaviour
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
        if (other.CompareTag("Player2"))
        {
            if (other.GetComponent<Player2>())
            {
                other.GetComponent<Player2>().HitOrBlock(frBlockStun, frHitStun);
            }
            else
            {
                other.transform.parent.GetComponent<Player2>().HitOrBlock(frBlockStun, frHitStun);
            }
            print(gameObject.name + " ha golpeado a player2");
            Destroy(gameObject);
        }
    }
}
