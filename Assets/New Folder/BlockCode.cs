using UnityEngine;

public class BlockCode : MonoBehaviour
{
   [SerializeField] GameObject block;

    private dash Dash;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float originalGravity;

    private float redColor = 1f;

    bool blocking = false;
    public bool canBlock = true;
    public float blockTime;
    public float maxBlockTime = 2.5f;

    public Color corInicial = Color.green;
    public Color corFinal = Color.red;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Dash = FindAnyObjectByType(typeof(dash)) as dash;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        originalGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(1) && !blocking && canBlock)
        {
            blocking = true;
            Dash.canDash = false;
            block.SetActive(true);
            rb.gravityScale = 0.2f;
            rb.linearVelocity = Vector2.zero;
        }
        if (Input.GetMouseButton(1))
        {
            blockTime += Time.deltaTime;

            if(blockTime == redColor)
            {
                sr.color = Color.Lerp(corInicial, corFinal, Mathf.PingPong(Time.time * redColor), 1);
            }

            if(blockTime >= maxBlockTime)
            {
                block.SetActive(false);
                blocking = false;
                Dash.canDash = true;
                rb.gravityScale = originalGravity;
                blockTime = 0f; 
            }
        }
        if (Input.GetMouseButtonUp(1) && blocking & canBlock)
        {
            blocking = false;
            Dash.canDash = true;
            block.SetActive(false);
            rb.gravityScale = originalGravity;
        }
    }
}
