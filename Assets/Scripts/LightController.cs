using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light[] lights;
    public float lightIntensity;
    public float lightDecreaseStep;

    private void FixedUpdate()
    {
        DecreaseLights();
    }

    void DecreaseLights()
    {
        foreach (Light light in lights)
        {
            light.intensity -= lightDecreaseStep;
        }
    }

    public void IncreaseLights(float amount)
    {
        foreach (Light light in lights)
        {
            light.intensity += amount;
        }
    }

}
