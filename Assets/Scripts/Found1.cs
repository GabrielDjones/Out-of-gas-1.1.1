using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Found1 : MonoBehaviour
{
    int encontrado;
    [SerializeField] TMP_Text texto;
    public string sceneName;

    bool car = false;
    void Update()
    {
        texto.text = "gasolinas encontradas: " + encontrado + "/4";
        if (encontrado == 4) { car = true; }
    }
    public void Encontrar()
    {
        encontrado++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Carro") && car)
        { 
            SceneManager.LoadScene(sceneName);
        }

    }
}

