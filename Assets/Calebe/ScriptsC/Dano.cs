using UnityEngine;

public class Dano : MonoBehaviour
{
    public int dano = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Vida>().LevarDano(dano);
        }
    }
}