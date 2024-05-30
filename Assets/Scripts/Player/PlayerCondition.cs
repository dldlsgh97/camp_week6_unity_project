using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCondition : MonoBehaviour
{
    public UICondition uICondition;

    Condition health { get { return uICondition.Health; } }
    Condition stamina { get { return uICondition.Stamina; } }

    public void Heal(float amount)
    {
        health.Add(amount);
    }
    public void Die()
    {
        Debug.Log("�÷��̾ �׾���.");
    }
    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
    }
}
