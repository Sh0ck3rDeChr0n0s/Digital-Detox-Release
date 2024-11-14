using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Settings : MonoBehaviour
{
    public GameObject Panel;
    public TMP_Dropdown ResolutionDr;
    public Toggle FullScr;

    Resolution[] resolutions;
    public int currentResolution = 0;
    void Start()
    {
        ResolutionDr.ClearOptions();
        List<string> option = new List<string>();
        resolutions = Screen.resolutions;


        for (int i = 0; i < resolutions.Length; i++)
        {
            string options = resolutions[i].width + "x" + resolutions[i].height;
            option.Add(options);
            if (resolutions[i].width==Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResolution = i;

            }
        }
        ResolutionDr.AddOptions(option);
        ResolutionDr.value = currentResolution;
        ResolutionDr.RefreshShownValue();
        Screen.fullScreen = true;

        
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
    public void CloseAndSave()
    {
        int Set = ResolutionDr.value;
        SetResolution(Set);
    }

}
