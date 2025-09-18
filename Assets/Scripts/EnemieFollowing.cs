using UnityEngine;
using UnityEngine.UIElements;
 
public class EnemieFollowing : MonoBehaviour
{
    [SerializeField] private float speed = 9;
 
    [SerializeField] private Transform target;
  
    void Awake()
    {
        void Awake()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
 

    void Update()
    {
        if (target == null) return;
 
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
