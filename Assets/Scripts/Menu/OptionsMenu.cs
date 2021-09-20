using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public int[] heights;
    public int[] widths;
    public TMP_Dropdown dropDown;

    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = new Resolution[heights.Length];

        for (int i = 0; i < heights.Length; i++)
        {
            resolutions[i] = new Resolution();
            resolutions[i].height = heights[i];
            resolutions[i].width = widths[i];
        }

        string[] resolutionNames = new string[resolutions.Length];
        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionNames[i] = resolutions[i].ToString();
        }

        dropDown.ClearOptions();
        dropDown.AddOptions(resolutionNames.ToList());
    }

    public void ChangeScreenType(bool isWindow)
    {
        if (isWindow)
            Screen.fullScreen = false;
        else
            Screen.fullScreen = true;
    }

    public void SetResolution(int i)
    {
        Screen.SetResolution(resolutions[i].width, resolutions[i].height, Screen.fullScreen);
    }
}
