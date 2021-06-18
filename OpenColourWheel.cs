using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;


public class OpenColourWheel : MonoBehaviour {
    [DllImport("__Internal")]
    private static extern void SetupMouse();

    private bool setupMouseFlag = false;

    public Canvas colourWheelCanvasPref;

    //Open canvas with color wheel when button in pushed
    public void Open()
    {
        if (!setupMouseFlag)
        {
#if !UNITY_EDITOR
    SetupMouse();
#endif
            setupMouseFlag = true;
        }

        Canvas colourWheelCanvas = Instantiate(colourWheelCanvasPref) as Canvas;
    }
}
