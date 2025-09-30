using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] ItemTemplate[] inventory;

    void Start()
    {
        inventory = new ItemTemplate[5];
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>())
        {
            AddItem(other.GetComponent<Item>());
        }
    }
    private void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = itemToAdd.itemTemplate;
                Destroy(itemToAdd.gameObject);
                break;
            }
        }
    }
}