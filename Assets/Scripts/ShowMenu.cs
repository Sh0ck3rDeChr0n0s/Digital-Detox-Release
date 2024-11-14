using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowMenu : MonoBehaviour
{
    private bool _isActive=false;
    public GameObject menu;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isActive)
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
            _isActive = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isActive)
        {
            menu.SetActive(false);
            Time.timeScale = 1f;
            _isActive = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
