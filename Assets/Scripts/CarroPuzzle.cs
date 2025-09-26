using UnityEngine;
using UnityEngine.UI;

public class CarroPuzzle : MonoBehaviour
{
    public int totalGasolinas = 3; 
    private int coletadas = 0;

    public GameObject botaoCarro;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (coletadas >= totalGasolinas)
            {
                botaoCarro.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            botaoCarro.SetActive(false); 
        }
    }

    public void ColetarGasolina()
    {
        coletadas++;
    }

    public void Escapar()
    {
        Debug.Log("Vitória! Você escapou com o carro!");
    
    }
}
