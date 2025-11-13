using UnityEngine;

public class VidaCode : MonoBehaviour
{
    public float life = 100f;
    public float lifeMax = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life = Mathf.Clamp(life, 0, lifeMax);
    }
}
