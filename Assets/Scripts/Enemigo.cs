using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private bool ganador;
    public AudioClip audioMuerte;
    private AudioSource audioSource;
    public GameObject balaEnemigo;
    private float speed = 1f;
    private Vector3 initPosition;
    private bool moverDerecha;
    private bool moverIzquierda;
    private Vector3 spawnBala;
    private int random;
    Animator animator;
    Rigidbody2D rb;
    Collider2D colider;
    private bool canShoot;
    private Player player;
    private SceneController sceneController;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        colider = GetComponent<Collider2D>();
        initPosition = transform.position;
        moverDerecha = true;
        moverIzquierda = false;
        canShoot = false;
        Invoke("Recargar", Random.Range(0f, 3f));
        audioSource = GetComponent<AudioSource>();
        ganador = false;

    }
    void OnDestroy()
    {
        sceneController = FindObjectOfType<SceneController>();
        sceneController.EliminarEnemigos();
    }
    void Update()
    {
        player = FindObjectOfType<Player>();
        ganador = player.gameOver;

        if (!ganador)
        {

            random = Random.Range(0, 10000);
            if (canShoot && random == 50)
            {
                spawnBala = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Instantiate(balaEnemigo, spawnBala, Quaternion.identity);
                canShoot = false;
                Invoke("Recargar", 3f);
            }
            if (transform.position.x < initPosition.x + 1.6f && moverDerecha)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                moverIzquierda = true;
                moverDerecha = false;
            }

            if (transform.position.x > initPosition.x - 1.6f && moverIzquierda)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                moverDerecha = true;
                moverIzquierda = false;
            }
        }
    }

    private void Recargar()
    {
        canShoot = true;
    }

    public void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "DJugador")
        {
            audioSource.PlayOneShot(audioMuerte);
            animator.SetBool("Vuelo", false);
            animator.SetBool("Muerto", true);
            Invoke("EliminarObjeto", 0.3f);
        }
    }

    private void EliminarObjeto()
    {
        Destroy(this.gameObject, 0);
    }
}
