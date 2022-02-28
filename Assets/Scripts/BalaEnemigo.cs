using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    private float speed = 3.5f;
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.y > -5)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject, 0);
        }
    }
    public void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject, 0);
        }
    }
}
