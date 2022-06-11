using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Switches : MonoBehaviour
{
    // button object
    [SerializeField] private Transform button;
    [SerializeField] private AudioMixer masterVolume;

    // button adjustment value
    [SerializeField] protected float buttonAdjustment = 0.01f;

    // determines if the switch is on or not
    protected bool on = false;

    [SerializeField] AudioSource clickOn;
    [SerializeField] AudioSource clickOff;


    protected void PlayTheSound(AudioSource aud)
    {
        float volume = 0;
        if (masterVolume != null)
        {
            Debug.Log("here");
            masterVolume.GetFloat("Master Volume", out volume);
        }
        volume = (volume + 80) / 100;
        AudioSource.PlayClipAtPoint(aud.clip, transform.position, volume);
    }

    // when an object is on the switch it stays on
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Possess" || other.tag == "Human" )
        {
            SwitchActivate();
            PlayTheSound(clickOn);
            // AudioSource.PlayClipAtPoint(clickOn.clip, transform.position, volume);
        }
        
    }

    // when a player leaves the switch it turns off
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Possess" || other.tag == "Human" )
        {
            SwitchDeactivate();
            PlayTheSound(clickOff);
            //AudioSource.PlayClipAtPoint(clickOff.clip, transform.position, volume);
        }
    }

    // returns if switch is on or off
    public bool GetStatus()
    {
        return on;
    }

    // adjusts button position and makes switch true
    protected virtual void SwitchActivate()
    {
        SwitchMovement(-buttonAdjustment);
        on = true;
    }

    // adjusts button position and makes switch false
    protected virtual void SwitchDeactivate()
    {
        SwitchMovement(buttonAdjustment);
        on = false;
    }

    // moves switch button up or down
    protected void SwitchMovement(float upDown)
    {
        button.position = new Vector3(0,upDown,0) + button.position;
    }


}
