using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSoundRandomizer : MonoBehaviour
{
    public AudioClip[] animalNoises;
    private AudioSource squeek;
    [Range(0.1f, 0.2f)]
    public float volumeChangeMultiplier = 0.2f;
    [Range(0.1f, 0.5f)]
    public float pitchChangeMultiplier = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        squeek = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<InventoryControls>().CheckControl())
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                squeek.clip = animalNoises[Random.Range(0, animalNoises.Length)];
                squeek.volume = Random.Range(0.3f - volumeChangeMultiplier, 0.3f);
                squeek.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier);
                squeek.PlayOneShot(squeek.clip);
            }
        }   
    }
}
