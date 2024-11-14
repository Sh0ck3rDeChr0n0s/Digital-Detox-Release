using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CleaningManager : MonoBehaviour
{

    int w = (int)(Screen.width / 16.4156f);
    int h = (int)(Screen.height / 12.9514f);

    public GameObject cleaningMenu;
    public GameObject cleaningTool;
    public GameObject player;
    private Bug bug;
    public static bool isEnded = true;
    public int spd = 5;
    // private bool isCleaning = false;
    public int Num_bugs { get { return num_bugs; } 
        set { num_bugs = value; }}
    private int num_bugs;
    int[] cords;
    public GameObject bug_prefab;
    public Transform parentTransform;

    public void Start()
    {
        print("w = " + w + ", h = " + h);
        cords = GenerateArray(w, h);
    }

    public static int[] GenerateArray(int width, int height)
    {
        int[] map = new int[width * height];
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            map[x] = x;
        }
        return map;
    }

    public void StartCleaning(int _num)
    {
        num_bugs = _num;
        Bug_Generate(num_bugs);
        isEnded = false;
        cleaningMenu.SetActive(true);
        player.SetActive(false);
    }

    public void Update()
    {
        if (!isEnded)
        {
            Vector3 mouse = new Vector3(Input.GetAxis("Mouse X") * spd * Time.deltaTime, Input.GetAxis("Mouse Y") * spd * Time.deltaTime, 0);
            cleaningTool.transform.Translate(mouse * spd);
        }
        if (num_bugs == 0)
        {
            isEnded = true;
            cleaningMenu.SetActive(false);
            player.SetActive(true);
        }
    }

    public void Bug_Generate(int _num)
    {
        cords = Mix(cords);
        for (int i = 0; i < _num; i++)
        {
            if ((cords[i] - (cords[i] / w) * w + 1) == 0)
            {
                print("cords = " + cords + " i = " + i);
            }
            Instantiate(bug_prefab, new Vector3((cords[i] - (cords[i] / w) * w + 1) * 16.4156f, (cords[i] / w + 1) * 12.9514f, 0), Quaternion.identity, parentTransform);
        }
    }

    int[] Mix (int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int currValue = arr[i];
            int randIndex = Random.Range(i, arr.Length);
            arr[i] = arr[randIndex];
            arr[randIndex] = currValue;
        }
        return arr;
    }

    

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Bug"))
    //     {
            
    //     }
    // }
}