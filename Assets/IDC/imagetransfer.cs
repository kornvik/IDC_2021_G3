using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imagetransfer : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    private RenderTexture rt;
    private Texture2D tex;
    private Rect rect;
    public int resolutionWidth;
    public int resolutionHeight;
    public int bytesPerPixel;
    private byte[] rawByteData;
     void Start()
    {
    // Setup a camera, texture and render texture
        rt = new RenderTexture(resolutionWidth, resolutionHeight, 24);
        cam.targetTexture = rt;
        rawByteData = new byte[resolutionWidth * resolutionHeight * bytesPerPixel];
        tex = new Texture2D(resolutionWidth, resolutionHeight, TextureFormat.RGB24, false);
        rect = new Rect(0, 0, resolutionWidth, resolutionHeight);
    }

    // Update is called once per frame
    void Update()
    {
        cam.targetTexture = rt;
        cam.Render();// Read pixels to texture
        RenderTexture.active = rt;
        tex.ReadPixels(rect, 0, 0);// Read texture to array
        Color[] framebuffer = tex.GetPixels();

        Debug.Log(framebuffer);
    }
}
