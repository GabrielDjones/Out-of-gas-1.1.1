using UnityEngine;

public class BlockCode : MonoBehaviour
{
   [SerializeField] GameObject block;
    bool blocking = false;
    public float BlockTime;
    private Rigidbody2D rb;
    private float originalGravity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !blocking)
        {
            blocking = true;
            block.SetActive(true);
            rb.gravityScale = 0.2f;
            rb.linearVelocity = Vector2.zero;
        }
        else if (Input.GetMouseButtonUp(1) && blocking)
        {
            blocking = false;
            block.SetActive(false);
            rb.gravityScale = originalGravity;
        }
    }
}
