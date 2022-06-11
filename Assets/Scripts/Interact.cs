using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// abstract class for interactable objects
public abstract class Interact : MonoBehaviour
{
    [SerializeField] private AudioMixer masterVolume;
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

    public abstract void Interaction(GameObject obj);


}
