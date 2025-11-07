using UnityEngine;

public class Hiding : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private HideManagement hideManager;

    private bool inRange = false;

    void Update()
    {
        // Só pode se esconder se o player estiver no range e ativo
        if (Input.GetKeyDown(KeyCode.E) && inRange && player.activeSelf)
        {
            player.SetActive(false);
            hideManager.EnterHiding();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HiddenPlace"))
        {
            Debug.Log("Entrou na área de esconderijo");
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HiddenPlace"))
        {
            Debug.Log("Saiu da área de esconderijo");
            inRange = false;

            // Se estava escondido, força a saída
            hideManager.ForceExit();
        }
    }

    public void ResetRange()
    {
        inRange = false;
    }
}