using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControls : MonoBehaviour
{
    // Singleton
    public static PauseControls Instance;

    // input action controls
    private MainControls controls;

    // if game is paused
    private bool paused = false;

    // pause menu
    [SerializeField] GameObject pauseMenu;


    // initiate controls
    private void Awake()
    {
        controls = new MainControls();
        Instance = this;
    }

    // returns pause state
    public bool GetPause()
    {
        return paused;
    }

    // pause game and unpause
    public void PauseGame()
    {
        if(paused)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
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

    // pause game if key is triggered
    private void Update()
    {
        if(controls.Main.Pause.triggered)
        {
            PauseGame();
        }
    }
}
