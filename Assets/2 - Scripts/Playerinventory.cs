using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] ItemTemplate[] inventory;

    void Start()
    {
        inventory = new ItemTemplate[5];
=======
    EnemyBehaviour enemyBehaviour;
    [HideInInspector] public ItemTemplate[] inventory;
    public InventoryUI[] inventoryUI;
    [HideInInspector] public bool playerIsAtGate, hasKey;
    public KeyCode interactionKey;

    void Start()
    {
        enemyBehaviour = FindFirstObjectByType<EnemyBehaviour>();
        inventory = new ItemTemplate[3];
>>>>>>> Stashed changes
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>())
        {
            AddItem(other.GetComponent<Item>());
        }
<<<<<<< Updated upstream
=======
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Gate") && playerIsAtGate == true)
        {
            GameMaster.Instance.OpenExitGate();
        }
        else if (other.CompareTag("Lever") && Input.GetKeyDown(interactionKey))
        {
            GameMaster.Instance.OpenKeyGate();
        }
>>>>>>> Stashed changes
    }
    private void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = itemToAdd.itemTemplate;
<<<<<<< Updated upstream
=======
                inventoryUI[i].SetSlot(itemToAdd);
                if (itemToAdd.itemTemplate.itemID == 2)
                {
                    hasKey = true;
                }
>>>>>>> Stashed changes
                Destroy(itemToAdd.gameObject);
                break;
            }
        }
    }
}