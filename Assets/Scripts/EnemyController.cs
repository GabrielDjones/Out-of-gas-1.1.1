using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemy;
    public Transform pontoDeSpawn;

    public float timeTillSpawn = 10f;

    float timePerSecund = 1f;

    bool ActiveEnemy = false;

    void Update()
    {
        if (ActiveEnemy)
        {
            timeTillSpawn -= timePerSecund * Time.deltaTime;
        }
        if (timeTillSpawn <= 0) 
        {
            ActiveEnemy = false;
            SpawnEnemy();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActiveEnemy = true;
  
        }
    }

    private void SpawnEnemy()
    {
        Vector3 posicao = pontoDeSpawn != null ? pontoDeSpawn.position : Vector3.zero;
        Quaternion rotacao = Quaternion.identity;

        GameObject copia = Instantiate(enemy, posicao, rotacao);
    }
}
