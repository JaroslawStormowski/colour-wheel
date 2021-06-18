using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetImage : MonoBehaviour
{

    // Use this for initialization
    void Start ()
    {
        GameObject Master = GameObject.Find("Master");
        Texture2D text = Master.GetComponent<ImageUpload>().texture;
        RawImage Rimage = this.GetComponent<RawImage>();
        Rimage.texture = text;
    }
}
