using UnityEngine;

public class WarpSpeedBattery : MonoBehaviour
{
    public bool ratRunning;
    public bool wiresConnected;

    public float chargeRate;

    [Header("Progress bar")]
    public LineRenderer lineRenderer;
    public Transform[] points;
    public Transform maxPoint;
    public Vector3 maxDistance;
    
    Transform currentPoint;

    private void Start()
    {
        currentPoint = points[1];
        maxDistance = maxPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(ratRunning && wiresConnected)
        {
            IncreaseBattery();
        }
        else
        {
            LowerBattery();
        }

        for(int i = 0; i < points.Length; i++)
        {
            lineRenderer.SetPosition(i, points[i].position);
        }
    }

    void IncreaseBattery()
    {
        if(currentPoint.position.x > maxDistance.x)
        {
            //enter warpspeed
        }
        else
        {
            currentPoint.transform.position += new Vector3(chargeRate, 0, 0) * Time.deltaTime;
        }
    }

    void LowerBattery()
    {
        if(currentPoint.position.x < -maxDistance.x)
        {
            //stop moving
        }
        else
        {
            currentPoint.transform.position += new Vector3(-chargeRate, 0, 0) * Time.deltaTime;

        }
    }

    

}
