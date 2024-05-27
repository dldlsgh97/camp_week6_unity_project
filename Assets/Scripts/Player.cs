using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController playerCtrl;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        playerCtrl = GetComponent<PlayerController>();
    }
}
