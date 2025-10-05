using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    #region Variables
    NavMeshAgent enemyAgent;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] ENEMY_STATE currentState;
    public Animator anim;
    private float walkingSpeed = 3;
    private float runningSpeed = 9;

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
                if (GameMaster.Instance.isPlayerVisible == true)
                {
                    enemyAgent.SetDestination(player.position);

                }
                else
                {
                    ChangeState(ENEMY_STATE.Searching);
                }
                break;

            case ENEMY_STATE.Searching: //Estado de busqueda tras perder al jugador
                searchTime = Random.Range(minMaxSearchTime.x, minMaxSearchTime.y);
                elapsedSearchTime += Time.deltaTime;
                if (elapsedSearchTime >= searchTime)
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
            ChangeState(ENEMY_STATE.Chasing);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeState(ENEMY_STATE.Searching);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameMaster.Instance.KilledPlayer();
        }
    }
    void ChangeState(ENEMY_STATE newState)
    {
        currentState = newState;
        switch (newState)
        {
            case ENEMY_STATE.Walking:
                enemyAgent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].position);
                anim.SetBool("IdleEnemy", false);
                anim.SetBool("WalkEnemy", true);
                anim.SetBool("RunEnemy", false);
                enemyAgent.speed = walkingSpeed;
                break;

            case ENEMY_STATE.Chasing:
                enemyAgent.SetDestination(player.position);
                anim.SetBool("IdleEnemy", false);
                anim.SetBool("WalkEnemy", false);
                anim.SetBool("RunEnemy", true);
                enemyAgent.speed = runningSpeed;
                break;

            case ENEMY_STATE.Searching: //Estado de busqueda tras perder al jugador
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
                    anim.SetBool("IdleEnemy", true);
                    anim.SetBool("WalkEnemy", false);
                    anim.SetBool("RunEnemy", false);
                    enemyAgent.speed = walkingSpeed;
                }
                break;
        }
    }
}
