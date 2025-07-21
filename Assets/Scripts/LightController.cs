using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light[] lights;
    public float lightDecreaseStep;

    private void Update()
    {
        DecreaseLights();
    }

    private void DecreaseLights()
    {
        foreach (Light light in lights)
        {
            light.intensity -= lightDecreaseStep * Time.deltaTime;
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