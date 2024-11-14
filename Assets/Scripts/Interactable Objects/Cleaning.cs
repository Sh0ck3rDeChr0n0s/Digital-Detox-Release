using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaning : MonoBehaviour
{
    
    public LayerMask isPlayer;
    public LayerMask isNotCorrupted;
    public bool isCleaned = false;
    private bool f = false;
    public float interactableRange;
    private bool playerInInteractableRange = false;
    private int num_bugs;
    public int min_bugs = 500;
    public int max_bugs = 1000;
    public GameObject Letter_E;
    public Material not_corrupted;

    void Start()
    {
        num_bugs = Random.Range(min_bugs, max_bugs + 1);
    }

    void Update()
    {
        if (f)
        {
            if (CleaningManager.isEnded)
            {
                f = false;
                isCleaned = true;
            }
        }
        else if (!isCleaned)
        {
            playerInInteractableRange = Physics.CheckSphere(transform.position, interactableRange, isPlayer);
            if (playerInInteractableRange)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // print("!E");
                    Letter_E.SetActive(false);
                    f = true;
                    gameObject.layer = isNotCorrupted;
                    gameObject.GetComponent<MeshRenderer>().material = not_corrupted;
                    TriggerCleaning(num_bugs);
                }
            }
        }
    }

    public void TriggerCleaning(int _num)
    {
        FindObjectOfType<CleaningManager>().StartCleaning(_num);
    }
}