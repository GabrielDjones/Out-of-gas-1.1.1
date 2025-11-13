using UnityEngine;

public class BulleControl   : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;

    public void Initialize(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}