using System;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Portal linkedPortal;
    [SerializeField] private MeshRenderer screen;
    private Camera playerCam;
    private Camera portalCam;
    RenderTexture viewTexture;


    private void Awake()
    {
        playerCam = Camera.main;
        portalCam = GetComponentInChildren<Camera>();

        portalCam.enabled = false;
    }

    private void CreateViewTexture()
    {
        if (viewTexture == null || viewTexture.width != Screen.width || viewTexture.height != Screen.height)
        {
            if (viewTexture != null)
            {
                viewTexture.Release();
            }

            viewTexture = new RenderTexture(Screen.width, Screen.height, 0);
            // render the view from the portal cam to the view texture
            portalCam.targetTexture = viewTexture;
            // display the view texture on the screen of the linked portal
            linkedPortal.screen.material.SetTexture("_MainTex",viewTexture);
        }
    }

    public void Render()
    {
        screen.enabled = false;
        CreateViewTexture();

        var m = transform.localToWorldMatrix * linkedPortal.transform.localToWorldMatrix *
                playerCam.transform.localToWorldMatrix;
        portalCam.transform.SetPositionAndRotation(m.GetColumn(3),m.rotation);
        
        portalCam.Render();

        screen.enabled = true;
    }
    
}