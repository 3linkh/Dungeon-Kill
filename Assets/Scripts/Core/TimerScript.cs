using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerScript : MonoBehaviour
{
    [Tooltip("The starting time for the timer in seconds.")]
    [SerializeField] private float startTime = 600f;

    [SerializeField] TextMeshProUGUI timerText;
    private float currentTime;

    private void Start()
    {
        
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
        }

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        //

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = "Time Remaining: " + timeString;
    }
}