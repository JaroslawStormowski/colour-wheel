using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Main : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ImageUploaderStart();

    public Color color;
    public Button btnPickColour;

    public int mouseX;
    public int mouseY;
    public bool mouseClick;

    // Use this for initialization
    void Start ()
	{
	    btnPickColour = btnPickColour.GetComponent<Button>();

#if !UNITY_EDITOR
    ImageUploaderStart();
#endif
    }

    // Change button color to show what was selected
    public void SetBtnColor(Color color)
    {
        var btnColors = btnPickColour.colors;
        btnColors.normalColor = color;
        btnColors.highlightedColor = Color.white;
        btnColors.pressedColor = Color.gray;

        btnPickColour.colors = btnColors;
    }

    public void MousePos(string data)
    {
        string[] arrdata = data.Split(Char.Parse(","));
        Int32.TryParse(arrdata[0], out mouseX);
        Int32.TryParse(arrdata[1], out mouseY);
        /*int down;
        Int32.TryParse(arrdata[2], out down);
        bool mouseClick;
        if (down == 0)
        {
            mouseClick = false;
        }
        else
        {
            mouseClick = true;
        }
        */
    }
}
