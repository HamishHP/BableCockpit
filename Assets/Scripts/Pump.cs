using UnityEngine;

public class Pump : MonoBehaviour
{
    public BallonPump ballonPump;
    public Animator animator;

    public float pumpAmount;

    private bool canPump = false;

    private void OnMouseUpAsButton()
    {
        if (canPump)
        {
            ballonPump.InflateBallon(pumpAmount);
            animator.SetTrigger("Pump");
        }
    }

    public void SetCanPump(bool isFocused)
    {
        canPump = isFocused;
    }
}