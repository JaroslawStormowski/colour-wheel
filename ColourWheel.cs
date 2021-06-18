using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.InteropServices;


public class ColourWheel : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SetupMouse();

    public Color color;

    private GameObject Master;
    private Camera cam;
    private Texture2D tex;
    private Boolean texFlag;

    // Use this for initialization
    void Start()
    {
        Master = GameObject.Find("Master");
        cam = Camera.main;

    }

    /*void Update()
    {

            if (Input.GetMouseButton(0))
            {
                Vector2 pos = Input.mousePosition;
                StartCoroutine(GetColor((int)pos.x, (int)pos.y));
                Master.GetComponent<Main>().color = color;
        }

            if (Input.GetMouseButtonUp(0))
            {
                Master.GetComponent<Main>().SetBtnColor(color);
                texFlag = false;
                Destroy(this.gameObject);
            }
    }
    */

    public void PointerDown()
    {
        //Vector2 pos = Input.mousePosition;
        //StartCoroutine(GetColor((int)pos.x, (int)pos.y));
        int x = Master.GetComponent<Main>().mouseX;
        int y = Master.GetComponent<Main>().mouseY;
        StartCoroutine(GetColor(x, y));
        Master.GetComponent<Main>().color = color;
    }

    public void PointerUp()
    {
        Master.GetComponent<Main>().SetBtnColor(color);
        texFlag = false;
        Destroy(this.gameObject);
    }

    public void MousePosJS()
    {
#if !UNITY_EDITOR
    SetupMouse();
#endif
    }


    // Get the color function
    IEnumerator GetColor(int x, int y)
    {
        if (!texFlag)
            yield return StartCoroutine(GetScreenshot());
        color = tex.GetPixel(x, y);
    }

    // Do screenshot to set texture for get collor function
    IEnumerator GetScreenshot()
    {
        yield return new WaitForEndOfFrame();
        //Rect viewRect = Camera.main.pixelRect;
        Rect viewRect = cam.pixelRect;
        int w = (int)viewRect.width;
        int h = (int)viewRect.height;
        tex = new Texture2D(w, h, TextureFormat.ARGB32, false);
        tex.ReadPixels(new Rect(0, 0, w, h), 0, 0, false);
        tex.Apply();
        texFlag = true;
    }

}
