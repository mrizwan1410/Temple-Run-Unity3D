using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;
    [SerializeField] float startTime = 5f;

    float timeLeft;

    private void Start()
    {
        timeLeft = startTime;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");
    }
}
