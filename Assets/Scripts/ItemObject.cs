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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if(data.type == ItemType.Consumable)
            {
                if(data.consumableData.type == ConsumeType.Speed)
                {
                    CharacterManager.Instance.Player.playerCtrl.SppedBuff(data.consumableData.value);
                    Destroy(gameObject);
                }
                else
                {
                    CharacterManager.Instance.Player.condition.Heal(data.consumableData.value);
                    Destroy(gameObject);
                }
            }
            
        }
    }

    
}
