using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadDeCaminar = 5f;

    private Rigidbody2D rb;
    private Vector2 movimiento;

    void Start()
    {
        Debug.Log("SCRIPT FUNCIONANDO");
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("No se encontro Rigidbody2D en este objeto.");
        }
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movimiento = new Vector2(x, y).normalized;

        if (x != 0 || y != 0)
        {
            Debug.Log("Input detectado: X=" + x + " Y=" + y);
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.MovePosition(rb.position + movimiento * velocidadDeCaminar * Time.fixedDeltaTime);
        }
    }
}