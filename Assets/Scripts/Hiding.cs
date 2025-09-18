using UnityEngine;
using UnityEngine.UIElements;

public class Hiding : MonoBehaviour
{
    public bool podeseesconder= false;
    public bool escondido = false;
    private Renderer playerRenderer;
    private MovimentoTopDown movimentoJogador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        movimentoJogador = GetComponent <MovimentoTopDown>();
    }

    // Update is called once per frame
    void Update()
    {
        if (podeseesconder && Input.GetKeyDown(KeyCode.E))
        {
            escondido = !escondido;

            playerRenderer.enabled = !escondido;
        }
    }
}
