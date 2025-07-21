using System.Collections;
using UnityEngine;

public class GlowstickShakeScript : MonoBehaviour
{
    public Light pointLight;
    public float maxBrightness = 100;
    public float lightIncrementAmount = 10f;

    public Material glowMat;
    public Color initialColour;
    public float initialGlowIntensity;
    public float minGlowIntensity, maxGlowIntensity;

    public Camera m_Camera;

    private bool begunDragging = false;
    private float camDistance = 0;
    private Vector3 glowStickPos;

    private Vector3 initialPos;

    private Vector3 direction;
    private Vector3 newPosition;
    public float minShakeVelocity = 30;

    private bool hasShaken = false;

    public GameSound shakeSound;
    public float shakeSoundTime = 0.5f;

    private void Awake()
    {
        //glowMat.EnableKeyword("_EmissionColor");
        glowMat.SetColor("_EmissionColor", initialColour * initialGlowIntensity);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        float glowVal = Mathf.InverseLerp(0, maxBrightness, pointLight.intensity);
        glowMat.SetColor("_EmissionColor", initialColour * Mathf.Lerp(minGlowIntensity, maxGlowIntensity, glowVal));
    }

    private void OnMouseDrag()
    {
        if (!begunDragging)
        {
            begunDragging = true;
            camDistance = (transform.position - m_Camera.transform.position).magnitude;
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = camDistance;
        glowStickPos = m_Camera.ScreenToWorldPoint(mousePos);

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;

        if (velocity > minShakeVelocity)
        {
            if (!hasShaken)
            {
                hasShaken = true;
                StartCoroutine(ShakeSoundDelay());
                IncrementGlow();
                SoundManagerScript.instance.PlaySoundClip(shakeSound);
            }
        }

        transform.position = glowStickPos;
    }

    private IEnumerator ShakeSoundDelay()
    {
        yield return new WaitForSeconds(shakeSoundTime);
        hasShaken = false;
    }

    private void IncrementGlow()
    {
        if (pointLight.intensity < maxBrightness)
        {
            pointLight.intensity += lightIncrementAmount;
        }
    }

    private void OnMouseUp()
    {
        begunDragging = false;
        transform.position = initialPos;
    }
}