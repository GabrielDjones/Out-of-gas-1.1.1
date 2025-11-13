using UnityEngine;

public class BulletCode : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float cooldown;

    private Vector3 mousePos;

    public float lifeTime = 1.5f;

    public int munição = 3;
    private bool canShoot = true;

    public float recoilForce = 5f; // força do recuo
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // pega o Rigidbody2D do player
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // z = 0 porque o jogo é 2D

        cooldown = Mathf.Clamp(cooldown, 0, 5f);

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        if (munição > 0 && cooldown <= 0f)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }

        if (Input.GetMouseButtonDown(2) && canShoot)
        {
            Shot();
            munição--;
            cooldown = 5f;
        }
    }

    private void Shot()
    {
        if (bulletPrefab != null && canShoot)
        {        
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Vector3 direction = (mousePos - firePoint.position).normalized;
            bullet.GetComponent<BulleControl>().Initialize(direction);

            if (rb != null)
            {
                rb.AddForce(-direction * recoilForce, ForceMode2D.Impulse);
            }
            Destroy(bullet, lifeTime);
            canShoot = true;
        }
    }
}