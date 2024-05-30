using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition Health;
    public Condition Stamina;
    void Start()
    {
        CharacterManager.Instance.Player.condition.uICondition = this;
    }
    void Update()
    {
        
    }
}
