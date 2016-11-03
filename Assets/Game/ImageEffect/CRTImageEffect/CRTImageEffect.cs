using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CRTImageEffect : MonoBehaviour
{
    [Header("Noise")]
    public Texture noiseTexture;
    public float noiseXSpeed = 100f;
    public float noiseYSpeed = 100f;
    [Range(0, 1.0f)]
    public float noiseCutoff = 0.35f;

    [Header("Vignette")]
    public Texture vignetteTexture;

    [Header("Line")]
    public Texture lineTexture;
    public Color lineColor = Color.white;

    [Header("Distortion")]
    public float distortionStrength = 3.0f;

    private string m_noiseTexPropertyName = "_NoiseTex";
    private string m_noiseXSpeedPropertyName = "_NoiseXSpeed";
    private string m_noiseYSpeedPropertyName = "_NoiseYSpeed";
    private string m_noiseCutoffPropertyName = "_NoiseCutoff";
    private string m_vignettePropertyName = "_VignetteTex";
    private string m_linePropertyName = "_LineTex";
    private string m_lineColorPropertyName = "_LineColor";
    private string m_nightVisionPropertyName = "_NightVisionColor";
    private string m_distortionStrengthPropertyName = "_DistortionSrength";

    private int m_noiseTexID;
    private int m_noiseXSpeedID;
    private int m_noiseYSpeedID;
    private int m_noiseCutoffID;
    private int m_vignetteTexID;
    private int m_lineTexID;
    private int m_lineColorID;
    private int m_nightVisionID;
    private int m_distortionStrengthID;

    private Material m_material;

    void Awake()
    {
        InitPropertyIDs();
        OnValidate();
    }


    private void InitPropertyIDs()
    {
        if (m_material == null)
            m_material = new Material(Shader.Find("Unlit/CRT Shader"));

        m_noiseTexID = Shader.PropertyToID(m_noiseTexPropertyName);
        m_noiseXSpeedID = Shader.PropertyToID(m_noiseXSpeedPropertyName);
        m_noiseYSpeedID = Shader.PropertyToID(m_noiseYSpeedPropertyName);
        m_noiseCutoffID = Shader.PropertyToID(m_noiseCutoffPropertyName);
        m_vignetteTexID = Shader.PropertyToID(m_vignettePropertyName);
        m_lineTexID = Shader.PropertyToID(m_linePropertyName);
        m_lineColorID = Shader.PropertyToID(m_lineColorPropertyName);
        m_distortionStrengthID = Shader.PropertyToID(m_distortionStrengthPropertyName);
    }


    private void OnValidate()
    {
        if (m_material == null)
            m_material = new Material(Shader.Find("Unlit/CRT Shader"));

        m_material.SetTexture(m_noiseTexID, noiseTexture);
        m_material.SetFloat(m_noiseXSpeedID, noiseXSpeed);
        m_material.SetFloat(m_noiseYSpeedID, noiseYSpeed);
        m_material.SetFloat(m_noiseCutoffID, noiseCutoff);
        m_material.SetTexture(m_vignetteTexID, vignetteTexture);
        m_material.SetTexture(m_lineTexID, lineTexture);
        m_material.SetColor(m_lineColorID, lineColor);
        m_material.SetFloat(m_distortionStrengthID, distortionStrength);
    }


    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, m_material);
    }
}