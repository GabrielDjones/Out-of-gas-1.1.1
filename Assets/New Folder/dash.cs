using UnityEngine;

public class dash : MonoBehaviour
{
    public float dashForce = 20f;        // For�a do dash
    public float dashDuration = 0.15f;   // Dura��o do dash
    public float dashCooldown = 1f;      // Tempo entre dashes

    private bool isDashing = false;
    private bool canDash = true;
    private float dashTime;

    private Rigidbody2D rb;
    private Vector2 dashDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Requer Rigidbody2D
    }

    void Update()
    {
        // Detecta clique do bot�o direito do mouse (MRB)
        if (Input.GetMouseButtonDown(0) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private System.Collections.IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        dashTime = 0f;

        // Faz o dash na dire��o que o personagem est� olhando
        dashDirection = transform.right; // usa o eixo local "para frente" (direita)

        // Executa o dash por um curto tempo
        while (dashTime < dashDuration)
        {
            rb.linearVelocity = dashDirection * dashForce;
            dashTime += Time.deltaTime;
            yield return null;
        }

        // Para o movimento
        rb.linearVelocity = Vector2.zero;
        isDashing = false;

        // Aguarda cooldown antes de permitir outro dash
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}

