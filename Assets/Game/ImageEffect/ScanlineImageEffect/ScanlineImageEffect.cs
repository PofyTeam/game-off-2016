using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScanlineImageEffect : MonoBehaviour {

    public Material effectMaterial;
    public Camera target;
    // Creates a private material used to the effect
    void Awake()
    {
        if (this.target == null)
            this.target = Camera.main;
        effectMaterial.SetFloat("_maskSize", target.pixelHeight*0.5f);
    }

    // Postprocess the image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effectMaterial);
    }
}
