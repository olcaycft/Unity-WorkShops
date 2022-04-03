using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera cameraA;
    public Camera cameraB;
    public Material cameraMatA;
    public Material cameraMatB;
    void Start()
    {
        SetupTextureForCameraA();
        SetupTextureForCameraB();
    }

    
    
    private void SetupTextureForCameraA()
    {
        if (cameraA.targetTexture !=null)
        {
            cameraA.targetTexture.Release();
        }

        cameraA.targetTexture = new RenderTexture(Screen.width,Screen.height,24);
        cameraMatA.mainTexture = cameraA.targetTexture;
    }
    
    private void SetupTextureForCameraB()
    {
        if (cameraB.targetTexture !=null)
        {
            cameraB.targetTexture.Release();
        }

        cameraB.targetTexture = new RenderTexture(Screen.width,Screen.height,24);
        cameraMatB.mainTexture = cameraB.targetTexture;
    }
}
