using System;
using UnityEngine;
using System.Collections;
using System.Xml;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CreateImg : MonoBehaviour
{

    public Button btnWithColor;
    public RawImage imgPref;
    public RectTransform imageStorage;
    public int ImgNumber=0;

    private GameObject Master;

    void Start()
    {
        Master = GameObject.Find("Master");
    }

    public void CreateNew()
    {
        //Texture2D tex = Master.GetComponent<DownloadImage>().texture;
        Texture2D tex_prime = GetComponent<ImageUpload>().texture;
        Texture2D tex = CopyTexture(tex_prime);
        //Graphics.CopyTexture(tex_prime, 0, 0, tex, 0, 0);
        Color col = btnWithColor.colors.normalColor;
        tex = ApplyColorToTexture(tex, col);
        RawImage img = Instantiate(imgPref) as RawImage;
        img.texture = tex;
        img.transform.SetParent(imageStorage.transform, false);
    }

    Texture2D ApplyColorToTexture(Texture2D tex, Color col)
    {

        int y = 0;
        while (y < tex.height)
        {
            int x = 0;
            while (x < tex.width)
            {
                Color actualCol = tex.GetPixel(x, y);
                Color setCol = new Color();
                setCol.b = (actualCol.b + col.b)/2;
                setCol.g = (actualCol.g + col.g) /2;
                setCol.r = (actualCol.r + col.r) /2;
                setCol.a = (actualCol.a + col.a) /2;
                tex.SetPixel(x, y, setCol);
                ++x;
            }
            ++y;
        }
        //Name the texture
        ++ImgNumber;
        tex.name = ("Image" + ImgNumber);

        //Finalize edition
        tex.Apply();

        return tex;
    }

    Texture2D CopyTexture(Texture2D tex)
    {
        var pix = tex.GetPixels32();
        var destTex = new Texture2D(tex.width, tex.height);
        destTex.SetPixels32(pix);
        destTex.Apply();

        return destTex;
    }
}
