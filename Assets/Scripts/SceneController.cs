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
    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            colocacion = new Vector3(primeraNave.x + (distanciaLateral * i), primeraNave.y, primeraNave.z);
            Spawn(enemigo, colocacion);
        }
        for (int i = 1; i <= 10; i++)
        {
            colocacion = new Vector3(primeraNave.x + (distanciaLateral * i), primeraNave.y-0.65f, primeraNave.z);
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
}
