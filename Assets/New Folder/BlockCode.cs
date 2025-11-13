using UnityEngine;

public class BlockCode : MonoBehaviour
{
    [SerializeField] GameObject block;

    private dash Dash;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float originalGravity;

    private float redColor = 1f;
    public float redColorTimer = 1.5f;

    bool blocking = false;
    public bool canBlock = true;
    public float blockTime;
    public float maxBlockTime = 2.5f;

    public float blockCooldown = 2f; // tempo de recarga após bloquear
    private float cooldownTimer;

    public Color corInicial;
    public Color corFinal = Color.red;

    void Start()
    {
        Dash = FindAnyObjectByType(typeof(dash)) as dash;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        originalGravity = rb.gravityScale;

        // Salva a cor original do objeto na inicialização
        corInicial = sr.color;
    }

    void Update()
    {

        // Atualiza o cooldown, caso esteja ativo
        if (!canBlock)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= blockCooldown)
            {
                canBlock = true;
                cooldownTimer = 0f;
            }
        }

        if (Input.GetMouseButtonDown(1) && !blocking && canBlock)
        {
            blocking = true;
            Dash.canDash = false;
            block.SetActive(true);
            rb.gravityScale = 0.2f;
            rb.linearVelocity = Vector2.zero;
        }

        if (Input.GetMouseButton(1) && canBlock)
        {
            blockTime += Time.deltaTime;

            // Quando o tempo de bloqueio aumenta, muda a cor gradualmente
            if (blockTime >= redColor)
            {
                sr.color = Color.Lerp(corInicial, corFinal, Mathf.PingPong(Time.time * redColorTimer, 1f));
            }

            // Quando o tempo máximo de bloqueio é atingido
            if (blockTime >= maxBlockTime)
            {
                EncerrarBloqueio();
            }
        }

        // Se o botão direito for solto antes do tempo máximo
        if (Input.GetMouseButtonUp(1) && blocking && canBlock)
        {
            EncerrarBloqueio();
        }
    }

    // Função para encerrar o bloqueio e restaurar o estado original
    private void EncerrarBloqueio()
    {
        blocking = false;
        Dash.canDash = true;
        block.SetActive(false);
        rb.gravityScale = originalGravity;
        blockTime = 0f;

        // Retorna à cor original
        sr.color = corInicial;

        // Inicia o cooldown
        canBlock = false;
        cooldownTimer = 0f;
    }
}