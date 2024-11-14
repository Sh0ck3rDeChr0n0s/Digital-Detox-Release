using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
     public int num;
    public void Play()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(num);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
