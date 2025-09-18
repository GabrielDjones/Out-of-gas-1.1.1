using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class found: MonoBehaviour
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
