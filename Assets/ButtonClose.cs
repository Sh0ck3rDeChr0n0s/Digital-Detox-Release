using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonClose : MonoBehaviour
{
    [SerializeField] private GameObject panel;



    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter)){
panel.SetActive(false);
               
        }
    }
}
