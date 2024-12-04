using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Variable para el Rigidbody2D
    private Rigidbody2D rb;

    // Variable para el SpriteRenderer
    private SpriteRenderer spriteRenderer;

    // Velocidad configurable desde el Inspector
    public float velocidad = 5f;

    // Awake se llama antes de Start
    void Awake()
    {
        // Obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Obtener el componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // FixedUpdate es llamado en intervalos regulares (ideal para lógica de física)
    void FixedUpdate()
    {
        // Detectar posición del ratón en la pantalla
        Vector3 posicionRaton = Input.mousePosition;

        // Si el ratón está en la mitad derecha de la pantalla
        if (posicionRaton.x > Screen.width / 2)
        {
            // Mover el objeto hacia la derecha multiplicado por la velocidad
            rb.velocity = new Vector2(velocidad, rb.velocity.y);

            // Voltear el sprite para mirar hacia la derecha (si es necesario)
            spriteRenderer.flipX = false;
        }
        // Si el ratón está en la mitad izquierda de la pantalla
        else if (posicionRaton.x < Screen.width / 2)
        {
            // Mover el objeto hacia la izquierda multiplicado por la velocidad
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);

            // Voltear el sprite para mirar hacia la izquierda
            spriteRenderer.flipX = true;
        }
        else
        {
            // Detener el movimiento horizontal
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
