using UnityEngine;

public class Salir : MonoBehaviour
{
    // Método que se llama desde el botón de salir
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");

        // Cierra la aplicación
        Application.Quit();

        // Esto solo funciona fuera del editor. Si quieres probarlo en el editor,
        // puedes usar Debug.Log o una función condicional para simularlo.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
