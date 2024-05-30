using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    [SerializeField] float curValue;
    [SerializeField] float maxValue;
    [SerializeField] float startValue;
    [SerializeField] float passiveValue;
    [SerializeField] Image uiBar;

    private void Start()
    {
        curValue = startValue;
    }

    private void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    private float GetPercentage()
    {
        return curValue / maxValue;
    }

    public void Add(float amount) 
    {
        curValue = MathF.Min(curValue + amount, maxValue);
    }
    public void Subtract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }
}
