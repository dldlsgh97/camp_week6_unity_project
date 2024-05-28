using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public PlayerController playerCtrl;
    void Start()
    {
        playerCtrl = CharacterManager.Instance.Player.playerCtrl;
    }
    public void JumpAnim()
    {
        playerCtrl.Jump();
    }
}
