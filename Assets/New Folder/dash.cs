using UnityEngine;
using System.Collections;

public class dash : MonoBehaviour
{
    [Header("Dash Settings")]
    public float minDashForce = 10f;     // Força mínima do dash
    public float maxDashForce = 40f;     // Força máxima do dash
    public float maxChargeTime = 2f;     // Tempo máximo para carregar o dash
    public float dashDuration = 0.15f;   // Duração do dash
    public float dashCooldown = 1f;      // Tempo de recarga entre dashes

    private bool isDashing = false;
    public bool canDash = true;
    private bool isCharging = false;

    private float chargeTime = 0f;
    private Rigidbody2D rb;
    private Vector2 dashDirection;
    private float originalGravity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale; 
    }

    void Update()
    {
        // Início do carregamento do dash
        if (Input.GetMouseButtonDown(0) && canDash && !isCharging)
        {
            isCharging = true;
            chargeTime = 0f;
            rb.gravityScale = 0.2f; 
            rb.linearVelocity = Vector2.zero;
        }

        // Enquanto estiver segurando o botão, acumula o tempo de carga
        if (isCharging && Input.GetMouseButton(0))
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0f, maxChargeTime);
        }

        // Ao soltar o botão: executa o dash
        if (Input.GetMouseButtonUp(0) && isCharging && canDash)
        {
            float t = chargeTime / maxChargeTime;
            float dashForce = Mathf.Lerp(minDashForce, maxDashForce, t);

            StartCoroutine(DashCoroutine(dashForce));

            isCharging = false;
            chargeTime = 0f;
        }
    }

    private IEnumerator DashCoroutine(float dashForce)
    {
        isDashing = true;
        canDash = false;

        dashDirection = transform.right;

        // Dash
        float elapsed = 0f;
        while (elapsed < dashDuration)
        {
            rb.linearVelocity = dashDirection * dashForce;
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Fim do dash — restaura gravidade e zera velocidade
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = originalGravity;

        isDashing = false;

        // Espera o cooldown antes de poder usar novamente
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}