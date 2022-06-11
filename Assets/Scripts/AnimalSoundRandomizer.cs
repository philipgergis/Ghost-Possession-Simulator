using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AnimalSoundRandomizer : MonoBehaviour
{
    public AudioClip[] animalNoises;
    private AudioSource squeek;
    [Range(0.1f, 0.2f)]
    public float volumeChangeMultiplier = 0.2f;
    [Range(0.1f, 0.5f)]
    public float pitchChangeMultiplier = 0.2f;
    [SerializeField] private AudioMixer masterVolume;

    // Start is called before the first frame update
    void Start()
    {
        squeek = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<ParentControls>().CheckControl())
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                //float volume = 0;
                //if (masterVolume != null)
                //{
                //    Debug.Log("here");
                //    masterVolume.GetFloat("Master Volume", out volume);
                //}
                //volume += 80;
                //volume = (volume + 80) / 100;
                //float volume = 2f;
                //squeek.clip = animalNoises[Random.Range(0, animalNoises.Length)];
                //squeek.volume = volume;
                //squeek.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier);
                //squeek.PlayOneShot(squeek.clip, volume);
                float volume = 0;
                if (masterVolume != null)
                {
                    Debug.Log("here");
                    masterVolume.GetFloat("Master Volume", out volume);
                }
                volume = (volume + 80) / 100;
                AudioSource.PlayClipAtPoint(squeek.clip, transform.position, volume);
            }
        }   
    }
}
