using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class WeightedSwitch : Switches
{
    // number of items to make switch go off
    [SerializeField] private int amount;

    // current amount of items on switch
    [ReadOnly] private int currentAmount;

    // text to indicate how many things needed
    [SerializeField] private TextMesh text;

    // update text and make amount 0
    private void Awake()
    {
        currentAmount = 0;
        TextUpdate();
    }

    // activates switch by moving it down, changing text color, and making on true
    protected override void SwitchActivate()
    {
        currentAmount++;
        TextUpdate();
        if(currentAmount >= amount)
        {
            SwitchMovement(-buttonAdjustment);
            on = true;
            text.color = Color.yellow;
        }
    }

    // deactivate switch by moving the switch back up and making it false
    protected override void SwitchDeactivate()
    {
        currentAmount--;
        TextUpdate();

        if(currentAmount < amount)
        {
            on = false;
        }

        // if the switch was on before, move button back
        if (currentAmount + 1 == amount)
        {
            SwitchMovement(buttonAdjustment);
        }
    }

    // change text to be current amount out of total amount
    private void TextUpdate()
    {
        text.text = $"{currentAmount} / {amount}";
    }

    // make text face player
    private void Update()
    {
        text.transform.LookAt(Camera.main.transform);
        
    }
}
