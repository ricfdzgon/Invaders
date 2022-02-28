using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject enemigo;
    private float distanciaLateral = 0.65f;
    private float distanciaVertical = 0.65f;
    private Vector3 primeraNave = new Vector3(-2.2f, 1.8f, 0f);
    private Vector3 colocacion;
    private int vidasPlayer;

    public SpriteRenderer vida1, vida2, vida3;
    void Start()
    {
        vidasPlayer = 3;
        for (int i = 1; i <= 10; i++)
        {
            colocacion = new Vector3(primeraNave.x + (distanciaLateral * i), primeraNave.y, primeraNave.z);
            Spawn(enemigo, colocacion);
        }
        for (int i = 1; i <= 10; i++)
        {
            colocacion = new Vector3(primeraNave.x + (distanciaLateral * i), primeraNave.y - 0.65f, primeraNave.z);
            Spawn(enemigo, colocacion);
        }
        for (int i = 1; i <= 10; i++)
        {
            colocacion = new Vector3(primeraNave.x + (distanciaLateral * i), primeraNave.y + 0.65f, primeraNave.z);
            Spawn(enemigo, colocacion);
        }

    }

    void Update()
    {


    }

    private void Spawn(GameObject prefab, Vector3 spawnPoint)
    {
        Instantiate(prefab, spawnPoint, Quaternion.identity);
    }

    public void RestarVidas()
    {
        vidasPlayer--;
    }
    public int GetVidass()
    {
        return vidasPlayer;
    }

    public void ContadorVidasSprite()
    {
        switch (this.vidasPlayer)
        {
            case 3:
                break;
            case 2:
                vida3.enabled = false;
                break;
            case 1:
                vida2.enabled = false;
                break;
            case 0:
                vida1.enabled = false;
                break;
        }
    }
}
