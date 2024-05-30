using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float CurValue;
    [SerializeField] float maxValue;
    [SerializeField] float startValue;
    public float PassiveValue;
    [SerializeField] Image uiBar;

    private void Start()
    {
        CurValue = startValue;
    }

    private void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    private float GetPercentage()
    {
        return CurValue / maxValue;
    }

    public void Add(float amount) 
    {
        CurValue = MathF.Min(CurValue + amount, maxValue);
    }
    public void Subtract(float amount)
    {
        CurValue = Mathf.Max(CurValue - amount, 0.0f);
    }

    public void SetToMaxValue()
    {
        CurValue = maxValue;
    }
}
