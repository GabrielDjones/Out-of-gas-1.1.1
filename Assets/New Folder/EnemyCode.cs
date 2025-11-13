using UnityEngine;

public class EnemyCode : MonoBehaviour
{
    public float dashForce = 10f;
    BulletCode bullet;
    dash dashManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullet = FindAnyObjectByType(typeof(BulletCode)) as BulletCode;
        dashManager = FindAnyObjectByType(typeof(dash)) as dash;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dashManager.canDash = true;
            dashManager.EnemyKill(dashForce);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("BulletPlayer"))
        {
            Destroy(collision.gameObject);
            bullet.munição++;
            Destroy(gameObject);
        }
    }
}
