using UnityEngine;
using UnityEngine.UI;

public class Barradevida : MonoBehaviour
{
    public Vida playerVida;
    public Slider barraVida;

    void Start()
    {
        barraVida.maxValue = playerVida.vidaMaxima;
        barraVida.value = playerVida.vidaAtual;
    }

    void Update()
    {
        barraVida.value = playerVida.vidaAtual;
    }
}

