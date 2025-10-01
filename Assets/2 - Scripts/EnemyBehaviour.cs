using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    #region Variables
    NavMeshAgent enemyAgent;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] ENEMY_STATE currentState;
    public enum ENEMY_STATE
    {
        Idle,
        Walking,
        Chasing,
        Stunned
    }

    [Header("Idle State")]
    public float idleTime; //Time for idling
    public Vector2 minMaxIdleTime; //Range for idleTime
    float elapsedIdleTime;

    [Header("Chasing State")]
    public Transform player;

    [Header("Stunned State")]
    public float stunTime; //Time for stunned
    public Vector2 minMaxStunTime; //Range for stunTime
    float elapsedStunTime;
    #endregion

    private void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        idleTime = Random.Range(minMaxIdleTime.x, minMaxIdleTime.y);
    }
    private void Update()
    {
        switch (currentState)
        {
            case ENEMY_STATE.Idle: //Estado de espera
                idleTime = Random.Range(minMaxIdleTime.x, minMaxIdleTime.y);
                elapsedIdleTime += Time.deltaTime;
                if (elapsedIdleTime >= idleTime)
                {
                    elapsedIdleTime = 0;
                    ChangeState(ENEMY_STATE.Walking);
                }
                break;

            case ENEMY_STATE.Walking: //Estado de caminata
                if (enemyAgent.remainingDistance <= enemyAgent.stoppingDistance)
                {
                    ChangeState(ENEMY_STATE.Idle);
                }
                break;

            case ENEMY_STATE.Chasing: //Estado de persecución
                enemyAgent.SetDestination(player.position);
                break;

            case ENEMY_STATE.Stunned: //Estado de aturdido tras ser atacado
                stunTime = Random.Range(minMaxStunTime.x, minMaxStunTime.y);
                elapsedStunTime += Time.deltaTime;
                if (elapsedStunTime >= idleTime)
                {
                    elapsedStunTime = 0;
                    ChangeState(ENEMY_STATE.Walking);
                }
                else if (enemyAgent.remainingDistance <= enemyAgent.stoppingDistance)
                {
                    ChangeState(ENEMY_STATE.Idle);
                }
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Found player");
            ChangeState(ENEMY_STATE.Chasing);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Lost Player");
            ChangeState(ENEMY_STATE.Walking);
        }
    }
    public void ChangeState(ENEMY_STATE newState)
    {
        currentState = newState;
        switch (newState)
        {
            case ENEMY_STATE.Walking:
                enemyAgent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].position);
                break;

            case ENEMY_STATE.Chasing:
                enemyAgent.SetDestination(player.position);
                break;

            case ENEMY_STATE.Stunned: //Estado de búsqueda tras perder al jugador
                stunTime = Random.Range(minMaxStunTime.x, minMaxStunTime.y);
                elapsedStunTime += Time.deltaTime;
                if (elapsedStunTime >= idleTime)
                {
                    elapsedStunTime = 0;
                    print("We is stunned");
                    ChangeState(ENEMY_STATE.Walking);
                }
                else if (enemyAgent.remainingDistance <= enemyAgent.stoppingDistance)
                {
                    print("Arrived to point");
                    ChangeState(ENEMY_STATE.Idle);
                }
                break;
        }
    }
}
