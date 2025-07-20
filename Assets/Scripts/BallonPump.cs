using UnityEngine;

public class BallonPump : MonoBehaviour
{
    GameManager gameManager;

    public float maxSize;
    float currentSize;
    public float minSize;
    public float warningSize;

    public float deflateStep;

    public Transform ballonTransform;
    public Vector3 baseScale;

    public bool canPump;
    bool poped;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        //ballonTransform.localScale = Vector3.one * maxSize;
        baseScale = minSize * Vector3.one;

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
        if (!poped)
        {
            ballonTransform.localScale -= deflateStep * ballonTransform.localScale;
            currentSize = ballonTransform.localScale.x;
        }
    }

    public void InflateBallon(float amount)
    {
        if (!canPump)
            return;
        if(currentSize > maxSize)
        {
            Pop();
            return;
        }       

        float newSize = currentSize + amount;
        /*
        if (newSize > maxSize)
        {
            ballonTransform.localScale = ballonTransform.localScale * maxSize;
            return;
        }
        */

        ballonTransform.localScale += newSize * baseScale;
    }

    void LostOxygen()
    {
        gameManager.Die("Ran out of oxygen");
    }

    void Pop()
    {
        Debug.Log("POP");
        Destroy(ballonTransform.gameObject);
        poped = true;
        gameManager.Die("Poped oxygen ballon");
    }
}
