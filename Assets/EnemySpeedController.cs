using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySpeedController : MonoBehaviour
{
    void Start()
    {
        
    }
    float timer;
    public float accelMultiplier;
    void Update()
    {
        timer += Time.deltaTime;
        GetComponent<NavMeshAgent>().speed += accelMultiplier * Time.deltaTime;
    }
}
