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
        transform.up = - new Vector2(target.position.x, target.position.y) + new Vector2(transform.position.x, transform.position.y); ;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            GameObject.Find("Manager").GetComponent<Level1Manager>().gameOver = true;
        }
    }
}
