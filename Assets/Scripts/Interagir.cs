using UnityEngine;

public class Interagir : MonoBehaviour
{
    public float interactRange = 2f;
    public LayerMask interactableLayer; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange, interactableLayer);

        foreach (Collider2D hit in hits)
        {
           
            IInteractable interactable = hit.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact(); 
                break; 
            }
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }

    public interface IInteractable
    {
        void Interact();
    }

}

