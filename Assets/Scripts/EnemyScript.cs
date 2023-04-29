using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        if (moveDirection != Vector2.zero)
        {
            transform.up = Vector2.SmoothDamp(transform.up, moveDirection, ref smoothVel, 0.1f, 10);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
