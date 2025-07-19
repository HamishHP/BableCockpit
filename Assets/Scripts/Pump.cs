using UnityEngine;

public class Pump : MonoBehaviour
{
    public BallonPump ballonPump;
    public Animator animator;

    public float pumpAmount;

    private void OnMouseUpAsButton()
    {
        ballonPump.InflateBallon(pumpAmount);
        animator.SetTrigger("Pump");
    }
}
