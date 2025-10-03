using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Image slotImage;
    TextMeshProUGUI slotText;
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
    void SetSlot(Item itemToSet)
    {
<<<<<<< Updated upstream

=======
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
                case 1: //Invisibilidad
                    GameMaster.Instance.PlayerInvis();
                    break;
                case 2: //Llave
                    playerInventory.playerIsAtGate = true;
                    break;
            }
            playerInventory.inventory[buttonIndex] = null;
            slotText.text = null;
            slotImage.color = Color.white;
        }
>>>>>>> Stashed changes
    }
}
