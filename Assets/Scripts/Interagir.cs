using UnityEngine;

public class Interagir : MonoBehaviour

{
    Found1 found;

    public Transform interactionPoint;
    public float interactionRadius = 0.5f;
    public LayerMask interactableLayer;

    private void Start()
    {
        found = FindAnyObjectByType(typeof(Found1)) as Found1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("interagiu1");
            Collider2D hit = Physics2D.OverlapCircle(interactionPoint.position, interactionRadius, interactableLayer);
            if (hit != null)
            {
                Debug.Log("interagiu2");
              
                if(found != null)
                {
                    Debug.Log("interagiu3");
                    found.Encontrar();
                    Destroy(hit.gameObject);
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


