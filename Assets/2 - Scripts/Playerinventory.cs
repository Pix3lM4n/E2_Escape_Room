using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    EnemyBehaviour enemyBehaviour;
    [HideInInspector] public ItemTemplate[] inventory;
    public InventoryUI[] inventoryUI;
    bool isEnemyInRange;

    void Start()
    {
        enemyBehaviour = FindFirstObjectByType<EnemyBehaviour>();
        inventory = new ItemTemplate[4];
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>())
        {
            AddItem(other.GetComponent<Item>());
        }
        else if (other.GetComponent<EnemyBehaviour>())
        {
            isEnemyInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EnemyBehaviour>())
        {
            isEnemyInRange = false;
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
                Destroy(itemToAdd.gameObject);
                break;
            }
        }
    }
    public void PlayerAttack()
    {
        if (isEnemyInRange)
        {
            print("Enemy is stunned");
            enemyBehaviour.ChangeState(EnemyBehaviour.ENEMY_STATE.Stunned);
        }
    }
}