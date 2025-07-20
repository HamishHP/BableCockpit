using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject deathScreen;
    public TextMeshProUGUI deathText;

    public void Die(string deathMessage)
    {
        deathScreen.SetActive(true);
        deathText.text = deathMessage;
    }
}
