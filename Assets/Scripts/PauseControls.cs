using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControls : MonoBehaviour
{
    private MainControls controls;
    private bool paused = false;


    private void Awake()
    {
        controls = new MainControls();
    }


    private void PauseGame()
    {
        if(paused)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
        paused = !paused;
    }

    // Enable controls
    private void OnEnable()
    {
        controls.Enable();
    }


    // disable controls
    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        if(controls.Main.Pause.triggered)
        {
            PauseGame();
        }
    }
}
