using UnityEngine;

public class Rat : MonoBehaviour
{
    public bool OnWheel;
    public Transform wheelPoint;

    public Transform[] hidePoints;

    public void PutOnWheel()
    {
        OnWheel = true;
        transform.position = wheelPoint.position;
    }

    public void Hide()
    {
        OnWheel = false;
        int i = Random.Range(0, hidePoints.Length);
        transform.position = hidePoints[i].position;
        transform.rotation = hidePoints[i].rotation;
    }

    private void OnMouseUpAsButton()
    {
        if (!OnWheel)
        {
            PutOnWheel();
        }
    }
}
