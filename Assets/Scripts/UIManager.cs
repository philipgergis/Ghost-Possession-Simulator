using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // quit game
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadAsylum()
    {
        SceneManager.LoadScene("Asylum Level");
    }
}
