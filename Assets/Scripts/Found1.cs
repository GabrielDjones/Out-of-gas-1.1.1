using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Found1 : MonoBehaviour
{
    int encontrado;
    [SerializeField] TMP_Text texto;
    public string sceneName;

    void Update()
    {
        texto.text = "gasolinas encontradas: " + encontrado + "/4";
        if (encontrado == 4) { SceneManager.LoadScene(sceneName); }
    }
    public void Encontrar()
    {
        encontrado++;
    }
}

