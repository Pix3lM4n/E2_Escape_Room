using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    public bool isPlayerVisible, isKeyGateOpen;
    public float playerInvisDuration, keyGateDuration;
    public GameObject exitGate, keyGate;
    public Transform keyGateSpawn;
    [SerializeField] float elapsedInvisTime, elapsedKeyGateTime;
    private float elapsedSoundTime;
    GameObject keyGateClone;
    PlayerInventory playerInventory;
    SceneMaster sceneMaster;
    public AudioSource SFXSource;
    public AudioResource ClickSound;

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
            elapsedSoundTime += Time.deltaTime;
            GateOpen();
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

    public void GateOpen()
    {
        if (elapsedSoundTime > 0.5f)
        {
            SFXSource.resource = ClickSound;
            SFXSource.Play();
            elapsedSoundTime = 0 ;
        }
        
    }
}
