using UnityEngine;

public class Interagir : MonoBehaviour

{


    public Transform interactionPoint;
    public float interactionRadius = 0.5f;
    public LayerMask interactable;
    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D hit = Physics2D.OverlapCircle(interactionPoint.position, interactionRadius, interactable);
            if (hit != null)
            {
                found foun = hit.GetComponent<found>();
                if (hit.CompareTag("Gasolina") && foun != null)
                {
                    Debug.Log("interagiu");
                    foun.Encontrar();
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (interactionPoint != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
        }
    }
}


