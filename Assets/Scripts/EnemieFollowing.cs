using UnityEngine;
using UnityEngine.UIElements;

public class EnemieFollowing : MonoBehaviour
{
    public float enemySpeed = 5.1f;
    public float chaseRange = 10f;
    public float TempoDeVida = 10f;

    private Transform target;
    
    public GameObject Player;
  
    private Vector3 initialPosition;
    private Rigidbody2D rb;
    private bool returningToStart = false;

    void Start()
    {
        initialPosition = transform.position;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            target = playerObj.transform;

        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, TempoDeVida);
    }

    void FixedUpdate()
    {
        if (target == null || rb == null)
            return;

        // Se o player está desativado, inicia o retorno
        if (!Player.activeSelf)
        {
            if (!returningToStart)
            {
                returningToStart = true;
            }

            MoveTo(initialPosition);

            if (Vector3.Distance(transform.position, initialPosition) < 0.1f)
            {
                returningToStart = false;
            }

            return;
        }

        if (returningToStart)
        {
            MoveTo(initialPosition);

            if (Vector3.Distance(transform.position, initialPosition) < 0.1f)
                returningToStart = false;

            return;
        }

        // Player ativo e dentro do alcance
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= chaseRange)
        {
            MoveTo(target.position);
        }
    }

    void MoveTo(Vector3 destination)
    {
        Vector2 direction = (destination - transform.position).normalized;
        rb.MovePosition(rb.position + direction * enemySpeed * Time.fixedDeltaTime);
    }
}
