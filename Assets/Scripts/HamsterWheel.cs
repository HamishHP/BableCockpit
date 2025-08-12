using UnityEngine;
using DG.Tweening;

public class HamsterWheel : MonoBehaviour
{
    public WarpSpeedBattery battery;


    public MeshRenderer wheelRenderer;
    public Transform wheelTransform;
    public float maxWheelSpeed;
    public float currentWheelSpeed;
    public Rat rat;

    float currentTime;
    public Vector2 waitTimeRange;
    float waitTime = 10;

    bool spinning;

    private void Start()
    {
        AddRat();
        
    }

    private void Update()
    {
        if (spinning)
        {
            currentTime += Time.deltaTime;
        }
        else if(currentWheelSpeed > 0)
        {
            currentWheelSpeed -= 1;
            
        }

        if (currentTime > waitTime)
        {
            RemoveRat();
            currentTime = 0;
        }

        wheelTransform.Rotate(0, 0, currentWheelSpeed * Time.deltaTime);
    }

    public void AddRat()
    {
        Debug.Log("add rat");
        currentWheelSpeed = maxWheelSpeed;
        spinning = true;
        newWaitTime();
        rat.PutOnWheel();
        battery.ratRunning = true;

    }

    void RemoveRat()
    {
        spinning = false;
        rat.Hide();
        battery.ratRunning = false;

    }

    void newWaitTime()
    {
        waitTime = Random.Range(waitTimeRange.x, waitTimeRange.y);
    }
}
