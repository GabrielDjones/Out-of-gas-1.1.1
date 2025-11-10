using UnityEngine;

public class EnemyCode : MonoBehaviour
{
    dash dashManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dashManager = FindAnyObjectByType(typeof(dash)) as dash;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            dashManager.canDash = true;
            Destroy(gameObject);
        }
    }
}
