using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPlayer : MonoBehaviour
{
    private float speed = 4f;
    void Start()
    {
    }

    void Update()
    {
        if (transform.position.y < 10)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject, 0);
        }
    }

    public void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Enemigo")
        {
            Destroy(this.gameObject, 0);
        }
    }
}
