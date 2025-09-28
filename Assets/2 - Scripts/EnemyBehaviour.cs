using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    NavMeshAgent enemyAgent;
    public Transform patrolPoint;

    void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        enemyAgent.SetDestination(patrolPoint.position);
    }
}
