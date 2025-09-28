using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Hiding : MonoBehaviour
{
    [SerializeField] private float time = 2f;
    [SerializeField] private GameObject player;
    [SerializeField] private HideManagement hideManager;

    private bool inRange = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange && player.activeSelf)
        {
            // Esconde o jogador
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
            StartCoroutine(ExitRangeAfterDelay());
        }
    }

    IEnumerator ExitRangeAfterDelay()
    {
        yield return new WaitForSeconds(time);
        inRange = false;
        Debug.Log("Saiu da área de interação por tempo");
    }

    public void ResetRange()
    {
        inRange = false;
    }
}
