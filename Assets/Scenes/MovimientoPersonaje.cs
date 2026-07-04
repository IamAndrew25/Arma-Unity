using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadDeCaminar = 5f;

    private Rigidbody2D rb;
    private Vector2 movimiento;
    private Animator anim; // 1. Añade esta variable aquí

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // 2. Añade esta línea aquí

        if (rb == null)
        {
            Debug.LogError("No se encontró Rigidbody2D en este objeto.");
        }
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movimiento = new Vector2(x, y).normalized;

        // 3. Añade esta línea para enviar la señal al Animator:
        // Si no te mueves, el valor será 0. Si te mueves, será 1.
        anim.SetFloat("Velocidad", movimiento.sqrMagnitude);
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.MovePosition(rb.position + movimiento * velocidadDeCaminar * Time.fixedDeltaTime);
        }
    }
}