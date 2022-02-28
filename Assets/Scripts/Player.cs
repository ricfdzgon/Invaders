using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer cartel;
    public bool gameOver=false;
    public AudioClip audioDisparo;
    private AudioSource audioSource;
    private float speed = 2.8f;
    private bool puedeMoverseMasIzquierda;
    private bool puedeMoverseMasDerecha;
    private bool puedeDisparar;
    public GameObject prefabDisparo;

    private Vector3 maxIzquierda = new Vector3(-5, -3, 0);
    private Vector3 maxDerecha = new Vector3(5, -3, 0);
    private Vector3 spawnBala;

    Rigidbody2D rb;
    Collider2D colider;
    void Start()
    {
        puedeDisparar = true;
        puedeMoverseMasIzquierda = true;
        puedeMoverseMasDerecha = true;
        rb = GetComponent<Rigidbody2D>();
        colider = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (transform.position.x <= maxIzquierda.x)
            {
                puedeMoverseMasIzquierda = false;
            }
            if (transform.position.x >= maxDerecha.x)
            {
                puedeMoverseMasDerecha = false;
            }


            if (Input.GetKey(KeyCode.LeftArrow) && puedeMoverseMasIzquierda)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                puedeMoverseMasDerecha = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && puedeMoverseMasDerecha)
            {
                puedeMoverseMasIzquierda = true;
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Space) && puedeDisparar)
            {
                puedeDisparar = false;
                spawnBala = new Vector3(transform.position.x, transform.position.y + 0.38f, transform.position.z);
                Instantiate(prefabDisparo, spawnBala, Quaternion.identity);
                audioSource.PlayOneShot(audioDisparo);
                Invoke("Recargar", 0.4f);
            }
        }
    }

    private void Recargar()
    {
        puedeDisparar = true;
    }
    public void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "DEnemigo")
        {
            gameOver = true;
            cartel.enabled = true;
            Debug.Log("GAME OVER");
        }
    }

}
