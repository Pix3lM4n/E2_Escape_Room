using UnityEngine;
[CreateAssetMenu(fileName = "New item", menuName = "Scriptable Objects/Item")]

public class ItemTemplate : ScriptableObject
{
    [Tooltip("Name of item")]
    public string itemName;
    public Color itemColor;
    [Tooltip("Numerical ID of item, must be an int")]
    public int itemID;
}
