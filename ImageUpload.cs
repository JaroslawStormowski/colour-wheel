using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class ImageUpload : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ClickButton();

    public Canvas canvasInfoPref;
    public Texture2D texture;

    IEnumerator LoadTexture(string url)
    {
        WWW image = new WWW(url);
        yield return image;
        texture = new Texture2D(1, 1);
        image.LoadImageIntoTexture(texture);
        Debug.Log("Loaded image size: " + texture.width + "x" + texture.height);
    }

    public void FileSelected(string url)
    {
        StartCoroutine(LoadTexture(url));
    }

    public void OnButtonPointerDown()
    {
        Canvas canvasInfo = Instantiate(canvasInfoPref) as Canvas;

#if UNITY_EDITOR
        string path = UnityEditor.EditorUtility.OpenFilePanel("Open image", "", "jpg,png,bmp");
        if (!System.String.IsNullOrEmpty(path))
            FileSelected("file:///" + path);
#else
        ClickButton ();
#endif
    }
}
