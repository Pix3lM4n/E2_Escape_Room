using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    #region Variables
    NavMeshAgent enemyAgent;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] private ENEMY_STATE currentState;
    public enum ENEMY_STATE
    {
        Idle,
        Walking,
        Chasing,
        Searching
    }

    [Header("Idle State")]
    public float idleTime; //Time for idling
    public Vector2 minMaxIdleTime; //Range for idleTime
    float elapsedIdleTime;

    [Header("Chasing State")]
    //[SerializeField] bool isPlayerOnRange;
    public Transform player;

    [Header("Searhing State")]
    public float searchTime; //Time for searching
    public Vector2 minMaxSearchTime; //Range for searchingTime
    float elapsedSearchTime;
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
                    print("We is walking");
                    ChangeState(ENEMY_STATE.Walking);
                }
                break;

            case ENEMY_STATE.Walking: //Estado de caminata
                if (enemyAgent.remainingDistance <= enemyAgent.stoppingDistance)
                {
                    print("Arrived to point");
                    ChangeState(ENEMY_STATE.Idle);
                }
                break;

            case ENEMY_STATE.Chasing: //Estado de persecución
                print("We is chasing");
                enemyAgent.SetDestination(player.position);
                break;

            case ENEMY_STATE.Searching: //Estado de búsqueda tras perder al jugador
                searchTime = Random.Range(minMaxSearchTime.x, minMaxSearchTime.y);
                elapsedSearchTime += Time.deltaTime;
                if (elapsedSearchTime >= idleTime)
                {
                    elapsedSearchTime = 0;
                    print("We is searching");
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
            ChangeState(ENEMY_STATE.Searching);
        }
    }
    void ChangeState(ENEMY_STATE newState)
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
        }
    }
}
