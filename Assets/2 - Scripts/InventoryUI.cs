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

    }
}
