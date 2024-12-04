using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadordesierras : MonoBehaviour
{
    // Prefab de la sierra que será instanciada
    [SerializeField]
    private GameObject sierraASpawnear;

    // Velocidad de generación de sierras, configurable desde el Inspector
    [SerializeField]
    private float velocidadSpawn = 2f;

    // Rango para la posición aleatoria en el eje X
    [SerializeField]
    private float rangoMinX = -2f;
    [SerializeField]
    private float rangoMaxX = 2f;

    private void Start()
    {
        StartSpawning(); // Comienza la generación de sierras al iniciar el juego
    }

    public void StartSpawning()
    {
        InvokeRepeating("Spawn", 1f, velocidadSpawn);
    }

    public void StopSpawning()
    {
        CancelInvoke("Spawn");
    }

    public void SetVelocidadSpawn(float nuevaVelocidad)
    {
        velocidadSpawn = nuevaVelocidad;
        StopSpawning();
        StartSpawning();
    }

    private void Spawn()
    {
        if (sierraASpawnear != null)
        {
            float posicionAleatoriaX = Random.Range(rangoMinX, rangoMaxX);
            Vector2 posicionSierra = new Vector2(posicionAleatoriaX, transform.position.y);
            Instantiate(sierraASpawnear, posicionSierra, Quaternion.identity);
            Debug.Log("Se ha generado una sierra en la posición: " + posicionSierra);
        }
        else
        {
            Debug.LogWarning("No se ha asignado un prefab para la sierra.");
        }
    }
}
