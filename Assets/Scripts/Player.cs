using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController playerCtrl;
    public PlayerCondition condition;

    public ItemData itemData;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        playerCtrl = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
    }
}
