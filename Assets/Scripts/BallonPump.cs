using UnityEngine;

public class BallonPump : MonoBehaviour
{
    public float maxSize;
    float currentSize;
    public float minSize;
    public float warningSize;

    public float deflateStep;

    public Transform ballonTransform;

    public bool canPump;

    private void Start()
    {
        //ballonTransform.localScale = Vector3.one * maxSize;
    }

    private void Update()
    {
        if(currentSize < warningSize)
        {
            //WARNING
        }


        if(currentSize < minSize)
        {
            LostOxygen();
        }
    }

    private void FixedUpdate()
    {
        deflateBallon();
    }

    void deflateBallon()
    {
        ballonTransform.localScale -= deflateStep * ballonTransform.localScale;
        currentSize = ballonTransform.localScale.x;
    }

    public void InflateBallon(float amount)
    {
        if (!canPump)
            return;

        if (currentSize > maxSize)
            Pop();

        float newSize = currentSize + amount;
        if (newSize > maxSize)
        {
            ballonTransform.localScale = Vector3.one;
            return;
        }

        ballonTransform.localScale += newSize * ballonTransform.localScale;
    }

    void LostOxygen()
    {

    }

    void Pop()
    {

    }
}
