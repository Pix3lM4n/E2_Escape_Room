using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    public bool isPlayerVisible, isKeyGateOpen;
    public float playerInvisDuration, keyGateDuration;
    public GameObject exitGate, keyGate;
    public Transform keyGateSpawn;
    [SerializeField] float elapsedInvisTime, elapsedKeyGateTime;
    GameObject keyGateClone;
    PlayerInventory playerInventory;
    SceneMaster sceneMaster;

    private void Awake()
    {
        Instance = this;
        playerInventory = FindFirstObjectByType<PlayerInventory>();
        sceneMaster = FindFirstObjectByType<SceneMaster>();
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
        sceneMaster.WinScene();
    }
    public void OpenKeyGate()
    {
        Destroy(keyGateClone.gameObject);
        isKeyGateOpen = true;
    }
    public void KilledPlayer()
    {
        sceneMaster.LoseScene();
    }
}
