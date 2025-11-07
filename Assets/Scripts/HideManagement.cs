using UnityEngine;

public class HideManagement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Hiding hidingScript;

    private bool isHiding = false;

    void Update()
    {
        // Se já está escondido e aperta E, sai do esconderijo
        if (Input.GetKeyDown(KeyCode.E) && isHiding)
        {
            ExitHiding();
        }
    }

    public void EnterHiding()
    {
        if (isHiding) return; // já está escondido, não faz nada

        isHiding = true;
        Debug.Log("Entrou no esconderijo");
    }

    private void ExitHiding()
    {
        player.SetActive(true);
        isHiding = false;
        hidingScript.ResetRange();
        Debug.Log("Saiu do esconderijo");
    }

    public void ForceExit()
    {
        if (isHiding)
        {
            Debug.Log("Saiu do esconderijo porque deixou a área");
            ExitHiding();
        }
    }
}