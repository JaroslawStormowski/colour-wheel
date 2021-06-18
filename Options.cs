using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System.IO;


public class Options : MonoBehaviour
{
    private Button btnDelete;
    private Button btnDownload;
    private Button btnCancel;
    private GameObject ImageCaller;

    [DllImport("__Internal")]
    private static extern void DownloadToCpu(byte[] bytes, int byteLenght, string name);

    void Start()
    {
        ImageCaller = GameObject.Find("Master").GetComponent<OpenOptions>().ImageCaller;
    }

    public void Delete () {
	    Destroy(ImageCaller);
        Destroy(this.gameObject);
	}

    public void Download()
    {
        Texture2D tex = (Texture2D) ImageCaller.GetComponent<RawImage>().texture;
        byte[] bytes = tex.EncodeToPNG();

#if !UNITY_EDITOR
    DownloadToCpu(bytes, bytes.Length, tex.name);
#else
        string path = UnityEditor.EditorUtility.SaveFilePanel("Save image", "", tex.name + ".png", "png");
        if (!System.String.IsNullOrEmpty(path))
            File.WriteAllBytes(path, bytes);
#endif

        Destroy(this.gameObject);
    }

    public void Cancel()
    {
        Destroy(this.gameObject);
    }
}
