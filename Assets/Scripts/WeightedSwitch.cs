using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class WeightedSwitch : Switches
{
    [SerializeField] private int amount;

    [ReadOnly] private int currentAmount;

    [SerializeField] private TextMesh text;

    private void Awake()
    {
        currentAmount = 0;
        TextUpdate();
    }

    protected override void SwitchActivate()
    {
        currentAmount++;
        TextUpdate();
        if(currentAmount >= amount)
        {
            on = true;
            text.color = Color.yellow;
        }
    }

    protected override void SwitchDeactivate()
    {
        currentAmount--;
        TextUpdate();
        if (currentAmount < amount)
        {
            on = false;
        }
    }

    private void TextUpdate()
    {
        text.text = $"{currentAmount} / {amount}";
    }

    private void Update()
    {
        text.transform.LookAt(Camera.main.transform);
        
    }
}
