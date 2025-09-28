using UnityEngine;

public class HideManagement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Hiding hidingScript;

    private bool isHiding = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isHiding)
        {
            player.SetActive(true);
            isHiding = false;
            hidingScript.ResetRange();
            Debug.Log("Saiu do esconderijo");
        }
    }

    public void EnterHiding()
    {
        isHiding = true;
        Debug.Log("Entrou no esconderijo");
    }
}

