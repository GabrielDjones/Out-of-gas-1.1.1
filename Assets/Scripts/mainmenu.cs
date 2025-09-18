using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainmenu : MonoBehaviour
{

    public void StartGame(string JogoPrincipal)
    {
        SceneManager.LoadScene(JogoPrincipal);
    }


}   
