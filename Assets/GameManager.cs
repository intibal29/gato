using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Instancia estática del GameManager
    public static GameManager instance;

    // Referencia al marcador en la UI
    public Text marcador;
    public Text nivelTexto;

    // Puntuación y nivel actuales
    private int puntuacion = 0;
    private int nivel = 1;

    // Estado del juego
    private bool gameOver = false;

    // Metas de puntuación por nivel
    [SerializeField]
    private int puntosPorNivel = 10;

    // Velocidad inicial de generación de sierras
    [SerializeField]
    private float velocidadInicialSpawn = 2f;

    private void Awake()
    {
        // Asignar esta instancia como única
        instance = this;
    }

    private void Start()
    {
        ActualizarUI();
        // Ajustar velocidad inicial de generación de sierras
        AjustarDificultad();
    }

    public void GameOver()
    {
        gameOver = true; // Establecer estado de "Game Over"
        Debug.Log("Game Over activado.");

        // Detener el generador de sierras
        GameObject generadorObj = GameObject.Find("generadordesierras");
        if (generadorObj != null)
        {
            generadordesierras generador = generadorObj.GetComponent<generadordesierras>();
            if (generador != null)
            {
                generador.StopSpawning();
            }
        }
    }

    public void incrementapuntuacion()
    {
        if (!gameOver)
        {
            puntuacion++; // Incrementar puntuación
            Debug.Log("Tu puntuación es: " + puntuacion);

            // Actualizar la UI
            ActualizarUI();

            // Verificar si se alcanzó la meta para avanzar al siguiente nivel
            if (puntuacion % puntosPorNivel == 0)
            {
                nivel++;
                Debug.Log("¡Has alcanzado el nivel " + nivel + "!");
                AjustarDificultad();
            }
        }
    }

    private void AjustarDificultad()
    {
        // Aumentar la velocidad de generación de sierras
        float nuevaVelocidad = velocidadInicialSpawn / (1 + (nivel + 1) * 0.5f);

        // Configurar la nueva velocidad en el generador
        GameObject generadorObj = GameObject.Find("generadordesierras");
        if (generadorObj != null)
        {
            generadordesierras generador = generadorObj.GetComponent<generadordesierras>();
            if (generador != null)
            {
                generador.SetVelocidadSpawn(nuevaVelocidad);
            }
        }
    }

    private void ActualizarUI()
    {
        marcador.text = ""+ puntuacion;
        nivelTexto.text = "NIVEL: " + nivel;
    }
}
