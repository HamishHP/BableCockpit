using UnityEngine;

public class HamsterWheel : MonoBehaviour
{
    public WarpSpeedBattery battery;


    public MeshRenderer wheelRenderer;
    public Rat rat;

    float currentTime;
    public Vector2 waitTimeRange;
    float waitTime = 10;


    private void Start()
    {
        AddRat();
        
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (!wheelRenderer.isVisible && currentTime > waitTime)
        {
            RemoveRat();
            Debug.Log("Remove rat");
        }
    }

    public void AddRat()
    {
        newWaitTime();
        rat.PutOnWheel();
        battery.ratRunning = true;
    }

    void RemoveRat()
    {
        rat.Hide();
        battery.ratRunning = false;
    }

    void newWaitTime()
    {
        waitTime = Random.Range(waitTimeRange.x, waitTimeRange.y);
    }
}
