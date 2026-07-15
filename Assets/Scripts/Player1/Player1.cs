using System.Collections;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed;
    public string horizontalAxis = "Horizontal";
    public Animator animator;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    public float moveInputHorizontal;
    public bool inutil = false;
    public bool isBlocking = false;
    private float inutilTimer = 0f;

    [Header("Bloqueos y vida")]
    public int numBlocks = 3; // Núm total de BLOQUEOS permitidos
    public int numVida = 2;
    public GameObject[] escudos;
    public GameObject[] vida;
    public GameObject cartelHit;
    public GameObject cartelBlock;
    public AudioSource sonido;
    public AudioClip sonidoHit;
    public AudioClip sonidoBlock;

    public Manager manager;


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * moveInputHorizontal, rb.velocity.y);
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(inutil == true)
        {
            moveInputHorizontal = 0f;
            inutilTimer -= Time.deltaTime;
            if (inutilTimer <= 0f ) 
            {
                inutil = false;
                animator.SetBool("damage", false);
                animator.SetBool("block", false);
            }
            return;
        }

        moveInputHorizontal = Input.GetAxisRaw(horizontalAxis);

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("fwalk", true);
            animator.SetBool("bwalk", false);

            isBlocking = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("bwalk", true);
            animator.SetBool("fwalk", false);

            print(gameObject.name + " está BLOQUEANDO");
            isBlocking = true;
        }
        else
        {
            animator.SetBool("fwalk", false);
            animator.SetBool("bwalk", false);

            isBlocking = false;
        }
    }

    public void HitOrBlock(float blockFrames, float hitFrames)
    {
        if (isBlocking && numBlocks > 0)
        {
            escudos[numBlocks - 1].SetActive(false);
            numBlocks--;
            print("Escudo restante: " + numBlocks);

            //Apaño
            ActivarInutil(blockFrames);

            animator.SetBool("block", true);
            StartCoroutine(CartelBlock(0.2f));
            sonido.PlayOneShot(sonidoBlock);
        }
        else
        {
            vida[numVida-1].SetActive(false);
            numVida--;
            StartCoroutine(CartelHit(0.2f));
            sonido.PlayOneShot(sonidoHit);

            if(numVida <= 0)
            {
                ActivarInutil(42000000f);

                // si muere gana el jugador 2
                manager.GanarRondaP2();

                animator.SetBool("dead", true);
                
                return;
            }
            print(gameObject.name + " ha recibido un golpe");

            //StartCoroutine(setBool("damage", 0.5f));
            ActivarInutil(hitFrames);
            animator.SetBool("damage", true);
            // agregar lógica para cuando el jugador recibe un golpe (ej. reducir salud, animación de golpe, etc.)
        }
    }

    public void ForwardWalk()
    {
        animator.Play("Fwalk");
    }

    public void BackWalk()
    {
        animator.Play("Bwalk");
    }

    public void ActivarInutil(float frames)
    {
        inutil = true;
        inutilTimer = frames / 60f;
    }

    public void DesactivarInutil()
    {
        inutil = false;

        Debug.Log(gameObject + " puede moverse");
    }

    IEnumerator setBool(string name, float time = 0.01f)
    {
        animator.SetBool(name, true);
        yield return new WaitForSeconds(time);
        animator.SetBool(name, false);
    }

    IEnumerator CartelHit(float duration)
    {
        cartelHit.SetActive( true);
        yield return new WaitForSeconds(duration);
        cartelHit.SetActive(false);
    }

    IEnumerator CartelBlock(float duration)
    {
        cartelBlock.SetActive(true);
        yield return new WaitForSeconds(duration);
        cartelBlock.SetActive(false);
    }
}
