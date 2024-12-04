using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawscript : MonoBehaviour
{
    // Velocidad de rotación configurable desde el Inspector
    public float velocidadDeRotacion = 100f;

    // FixedUpdate se llama en intervalos regulares (ideal para física y transformaciones constantes)
    void FixedUpdate()
    {
        // Rotar el objeto continuamente en el eje Z
        transform.Rotate(0, 0, velocidadDeRotacion * Time.deltaTime);
    }

    // Detectar colisiones con objetos que tengan un Collider2D y sean un Trigger
    void OnTriggerEnter2D(Collider2D colision)
    {
        // Imprimir en consola el nombre del objeto con el que colisiona
        Debug.Log("Colisión detectada con: " + colision.gameObject.name);

        // Comprobar si el objeto que colisionó tiene la etiqueta "suelo"
        if (colision.tag == "suelo")
        {
            // Incrementar la puntuación en el GameManager
            GameManager.instance.incrementapuntuacion();

            // Imprimir mensaje en consola
            Debug.Log("He tocado suelo.");

            // Destruir el objeto actual
            Destroy(gameObject);
        }

        // Si colisiona con el objeto etiquetado como "gato"
        if (colision.gameObject.tag == "gato")
        {
            Debug.Log("Has muerto, gato."); // Mensaje en consola
            Destroy(colision.gameObject); // Eliminar al jugador
            GameManager.instance.GameOver(); // Llamar al método GameOver de la instancia
        }
    }
}
