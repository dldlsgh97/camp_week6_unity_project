using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInterattable
{
    public string GetInteractName();
    public string GetInteractDescription();
    public void OnInteract();
}
public class ItemObject : MonoBehaviour, IInterattable
{
    [SerializeField] ItemData data;
    [SerializeField] bool isPickup = false;

    private void Start()
    {
        isPickup = false;
    }
    public string GetInteractName()
    {
        string str = $"{data.ItemName}";
        return str;
    }
    public string GetInteractDescription()
    {
        string str = $"{data.ItemDescription}";
        return str;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemData = data;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if(data.type == ItemType.Consumable && !isPickup)
            {
                if(data.consumableData.type == ConsumeType.Speed)
                {
                    isPickup = true;
                    CharacterManager.Instance.Player.playerCtrl.SppedBuff(data.consumableData.value);
                    Destroy(gameObject);
                }
                else
                {
                    isPickup = true;
                    CharacterManager.Instance.Player.condition.Heal(data.consumableData.value);
                    Destroy(gameObject);
                }
            }
            
        }
    }

    

    
}
