using UnityEngine;

public class Salir : MonoBehaviour
{
    // Método que se llama desde el botón de salir
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");

        // Cierra la aplicación
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
