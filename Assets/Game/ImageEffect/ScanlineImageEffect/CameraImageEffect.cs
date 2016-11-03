using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraImageEffect : MonoBehaviour {

    public float intensity;
    public Material effectMaterial;
    public Camera target;
    // Creates a private material used to the effect
    void Awake()
    {
        if (this.target == null)
            this.target = GetComponent<Camera>();
        effectMaterial.SetFloat("_maskSize", target.pixelHeight*0.5f);
    }

    // Postprocess the image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //if (intensity == 0)
        //{
        //    Graphics.Blit(source, destination);
        //    return;
        //}

        //material.SetFloat("_bwBlend", intensity);
        Graphics.Blit(source, destination, effectMaterial);
    }
}
