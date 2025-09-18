using UnityEngine;

public class MovimentoTopDown : MonoBehaviour
{
    public float moveSpeed = 5f; //velocidade do player
    private Rigidbody2D rb; // adicinar o Rigidbody2D no gamecontroller e no player
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura o input do jogador
        movement.x = Input.GetAxisRaw("Horizontal"); // anda para os lado A/S
        movement.y = Input.GetAxisRaw("Vertical");  // anda para cima e para baixo W/S
        movement.Normalize(); 
    }

    void FixedUpdate()
    {
        // Move o personagem
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
