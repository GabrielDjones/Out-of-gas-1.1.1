using UnityEngine;

public class BlockCode : MonoBehaviour
{
   [SerializeField] GameObject block;
    bool blocking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1) && !blocking)
        {
            blocking = true;
            block.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(1) && blocking)
        {
            blocking = false;
            block.SetActive(false);
        }
    }
}
