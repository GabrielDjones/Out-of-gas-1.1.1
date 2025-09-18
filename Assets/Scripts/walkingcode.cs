using UnityEngine;

public class walkingcode : MonoBehaviour

{
    private float eixoX;
    private float eixoY;
    public float speed;
    private Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        eixoX = Input.GetAxisRaw("Horizontal");
        eixoY = Input.GetAxisRaw("Vertical");

        body.linearVelocity = new Vector2(eixoX, eixoY) * speed;

    }
}
