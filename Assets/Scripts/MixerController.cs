using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    private void Start()
    {
        float test;
        Slider slide = GetComponent<Slider>();
        mixer.GetFloat("Master Volume", out test);
        slide.value = test;

    }

    public void SetVolume(float vol)
    {
        mixer.SetFloat("Master Volume", vol);
    }
}
