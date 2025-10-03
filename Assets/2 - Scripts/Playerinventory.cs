using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [HideInInspector] public ItemTemplate[] inventory;
    EnemyBehaviour enemyBehaviour;
    public InventoryUI[] inventoryUI;
    [HideInInspector] public bool playerIsAtGate, hasKey;
    public KeyCode interactionKey;

    void Start()
    {
        enemyBehaviour = FindFirstObjectByType<EnemyBehaviour>();
        inventory = new ItemTemplate[3];
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>())
        {
            AddItem(other.GetComponent<Item>());
        }
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
    }
    private void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = itemToAdd.itemTemplate;
                inventoryUI[i].SetSlot(itemToAdd);
                if (itemToAdd.itemTemplate.itemID == 2)
                {
                    hasKey = true;
                }
                Destroy(itemToAdd.gameObject);
                break;
            }
        }
    }
}