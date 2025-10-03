using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    public bool isPlayerVisible, isKeyGateOpen;
    public float playerInvisDuration, keyGateDuration;
    [SerializeField] float elapsedInvisTime, elapsedKeyGateTime;
    public GameObject exitGate, keyGate;
    GameObject keyGateClone;
    public Transform keyGateSpawn;
    PlayerInventory playerInventory;

    private void Awake()
    {
        Instance = this;
        playerInventory = FindFirstObjectByType<PlayerInventory>();
    }
    void Start()
    {
        isPlayerVisible = true;
        keyGateClone = Instantiate(keyGate, keyGateSpawn);
    }
    void Update()
    {
        if (isPlayerVisible == false)
        {
            elapsedInvisTime += Time.deltaTime;
            if (elapsedInvisTime >= playerInvisDuration)
            {
                elapsedInvisTime = 0;
                isPlayerVisible = true;
            }
        }

        if (isKeyGateOpen == true)
        {
            elapsedKeyGateTime += Time.deltaTime;
            if (elapsedKeyGateTime >= keyGateDuration) 
            {
                elapsedKeyGateTime = 0;
                isKeyGateOpen = false;
                if (isKeyGateOpen == false)
                {
                    print("Gate is closed");
                    keyGateClone = Instantiate(keyGate, keyGateSpawn);
                }
            }
        }

        if (playerInventory.hasKey == true)
        {
            Destroy(keyGateClone.gameObject);
        }
    }
    public void PlayerInvis()
    {
        isPlayerVisible = false;
    }
    public void OpenExitGate()
    {
        Destroy(exitGate.gameObject);
    }
    public void OpenKeyGate()
    {
        Destroy(keyGateClone.gameObject);
        isKeyGateOpen = true;
    }
}
