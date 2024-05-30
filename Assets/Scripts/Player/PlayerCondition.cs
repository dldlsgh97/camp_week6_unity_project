using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCondition : MonoBehaviour
{
    public UICondition uICondition;

    Condition health { get { return uICondition.Health; } }
    Condition stamina { get { return uICondition.Stamina; } }

    [SerializeField] Transform respawnPoint;
    [SerializeField] GameObject dieUI;

    public void Heal(float amount)
    {
        health.Add(amount);
    }
    
    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
    }
    private void Update()
    {
        stamina.Add(stamina.PassiveValue * Time.deltaTime);

        if(health.CurValue <= 0.0f)
        {
            Die();
        }
    }
    public void Die()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        dieUI.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(5);
        dieUI.SetActive(false);
        Time.timeScale = 1;
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        health.SetToMaxValue();
        stamina.SetToMaxValue();
    }
    
}
