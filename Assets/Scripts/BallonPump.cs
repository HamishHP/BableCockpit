using UnityEngine;

public class BallonPump : MonoBehaviour
{
    private GameManager gameManager;

    public float maxSize;
    private float currentSize;
    public float minSize;
    public float warningSize;

    public float deflateStep;

    public Transform ballonTransform;
    public Vector3 baseScale;

    public bool canPump;
    private bool poped;

    public GameSound pumpSound, popSound, alarmSound;
    public GameEvent shutUpEvent; //probably will also just be the game end event. To stop all other sound sources when game over

    private AudioSource currentAlarm;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        //ballonTransform.localScale = Vector3.one * maxSize;
        baseScale = minSize * Vector3.one;
    }

    private void Update()
    {
        if (currentSize < warningSize)
        {
            if (currentAlarm == null)
            {
                currentAlarm = SoundManagerScript.instance.PlaySoundClip(alarmSound, true, ballonTransform);
            }
        }
        else
        {
            if (currentAlarm != null)
            {
                Destroy(currentAlarm.gameObject);
                currentAlarm = null;
            }
        }

        if (currentSize < minSize)
        {
            LostOxygen();
        }
    }

    private void FixedUpdate()
    {
        deflateBallon();
    }

    private void deflateBallon()
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
        if (currentSize > maxSize)
        {
            Pop();
            return;
        }

        SoundManagerScript.instance.PlaySoundClip(pumpSound);

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

    private void LostOxygen()
    {
        shutUpEvent.TriggerEvent();
        gameManager.Die("Ran out of oxygen");
        gameObject.SetActive(false);
    }

    private void Pop()
    {
        shutUpEvent.TriggerEvent();
        SoundManagerScript.instance.PlaySoundClip(popSound);
        Debug.Log("POP");
        Destroy(ballonTransform.gameObject);
        poped = true;
        gameManager.Die("Popped oxygen balloon");
        gameObject.SetActive(false);
    }

    public void SetCanPump(bool isFocused)
    {
        canPump = isFocused;
    }
}