using UnityEngine;

public class Hiding : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private HideManagement hideManager;

    private bool inRange = false;

    void Update()
    {
        // S� pode se esconder se o player estiver no range e ativo
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
            Debug.Log("Entrou na �rea de esconderijo");
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HiddenPlace"))
        {
            Debug.Log("Saiu da �rea de esconderijo");
            inRange = false;

            // Se estava escondido, for�a a sa�da
            hideManager.ForceExit();
        }
    }

    public void ResetRange()
    {
        inRange = false;
    }
}