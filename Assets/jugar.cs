using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar escenas

public class Jugar : MonoBehaviour
{
    // Método que se llama desde el botón para iniciar el juego
    public void IrAlJuego()
    {
        Debug.Log("Cargando la escena del juego...");

        
        SceneManager.LoadScene("escenaJuego");
    }
}
