using UnityEngine;

public class BotaoGasolina : MonoBehaviour
{
    public GameObject gasolinaBloqueada;
    private bool usado = false; 

    public void AtivarGasolina()
    {
        if (!usado)
        {
            gasolinaBloqueada.SetActive(true);
            usado = true;
        }
    }
}
