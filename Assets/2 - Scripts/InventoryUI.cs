using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Image slotImage;
    TextMeshProUGUI slotText;
    int slotID;
    PlayerInventory playerInventory;

    private void Awake()
    {
        slotImage = GetComponent<Image>();
        slotText = GetComponentInChildren<TextMeshProUGUI>();
        playerInventory = FindFirstObjectByType<PlayerInventory>();
    }
    void Start()
    {
        slotText.text = null;
    }
    public void SetSlot(Item itemToSet)
    {
        slotText.text = itemToSet.itemTemplate.itemName;
        slotImage.color = itemToSet.itemTemplate.itemColor;
        slotID = itemToSet.itemTemplate.itemID;
    }
    public void ClearSlot(int buttonIndex)
    {
        if (playerInventory.inventory[buttonIndex] != null)
        {
            switch (slotID)
            {
                case 1:
                    playerInventory.PlayerAttack();
                    break;
            }
            slotText.text = null;
            slotImage.color = Color.white;
        }
    }
}
