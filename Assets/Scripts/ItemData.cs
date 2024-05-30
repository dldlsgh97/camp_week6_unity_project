using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable
}
public enum ConsumeType
{
    Health,
    Stamina,
    Speed
}
[System.Serializable]
public class ItemDataConsumable
{
    public ConsumeType type;
    public float value;
}
[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string ItemName;
    public string ItemDescription;
    public ItemType type;
    public GameObject DropPrefab;

    [Header("Consumable Data")]
    public ItemDataConsumable consumableData;
}
