using UnityEngine;

public class Interagir : MonoBehaviour

{
    Found1 found;

    public Transform interactionPoint;
    public float interactionRadius = 0.5f;
    public LayerMask interactableLayer;

    GasAnimation gas;
    private void Start()
    {
        found = FindAnyObjectByType(typeof(Found1)) as Found1;
        gas = FindAnyObjectByType(typeof (GasAnimation)) as GasAnimation;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D hit = Physics2D.OverlapCircle(interactionPoint.position, interactionRadius, interactableLayer);
            if (hit != null)
            {
                if (found != null)
                {
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


