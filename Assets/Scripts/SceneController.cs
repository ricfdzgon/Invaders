using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public GameObject enemigo;
    private float distanciaLateral = 0.65f;
    private Vector3 primeraNave = new Vector3(-2.2f, 1.8f, 0f);
    private Vector3 colocacion;
    private int vidasPlayer, totalEnemigos;
    public int puntos;
    private float tiempo = 180;
    public SpriteRenderer vida1, vida2, vida3, win;
    private Scene escenaActiva;
    public Text contadorPuntos;
    public Text contadorTiempo;


    void Start()
    {
        escenaActiva = SceneManager.GetActiveScene();
        totalEnemigos = 30;
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
        if (tiempo >= 0)
        {
            tiempo -= Time.deltaTime;
            contadorTiempo.text = formatearTiempo(tiempo);
        }
        else
        {
            contadorTiempo.text = "00:00";
            GameOver();
        }
    }
    public void EliminarEnemigos()
    {
        puntos += 100;
        CambiarTextoPuntos();
        totalEnemigos--;
        if (totalEnemigos == 0)
        {
            Win();
        }
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

    private void Win()
    {
        win.enabled = true;
        Invoke("CargarEscena", 5f);
    }

    private void CargarEscena()
    {
        if (escenaActiva.name == "Primera")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void CambiarTextoPuntos()
    {
        contadorPuntos.text = puntos.ToString();
    }

    private string formatearTiempo(float tiempo)
    {
        string minutos = Mathf.Floor(tiempo / 60).ToString("00");
        string segundos = Mathf.Floor(tiempo % 60).ToString("00");

        return minutos + ":" + segundos;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
    }
}
