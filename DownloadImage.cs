using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DownloadImage : MonoBehaviour
{

    public string url = "https://image.freepik.com/free-photo/basic-color-wheel_61-1885.jpg";

    public WWW www;
    public Texture2D texture;

    // Use this for initialization
    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            texture = www.texture;
        }
    }
}