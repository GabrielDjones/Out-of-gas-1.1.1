using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaAtual;
    void Start()
    {
        vidaAtual = vidaMaxima;
    }
    public void LevarDano(int dano)
    {
        vidaAtual -= dano;
        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }
    public void Curar(int quantidade)
    {
        vidaAtual += quantidade;
        if (vidaAtual > vidaMaxima)
        {
            vidaAtual = vidaMaxima;
        }
    }
    void Morrer()
    {
        Debug.Log("O personagem morreu!");
        Destroy(gameObject);
    }
}