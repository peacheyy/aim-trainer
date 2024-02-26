using UnityEngine;
using TMPro;

public class DisplayTime : MonoBehaviour {
    public float timeRemaining = 60;
    public bool timerRunning = false;
    public TextMeshProUGUI timeText;

    private void Start() {
        timerRunning = true;
    }

    void Update() {
        if (timerRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                DisplayRemainingTime(timeRemaining);
            }
            else {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerRunning = false;
                
            }
        }
    }

    void DisplayRemainingTime(float timeToDisplay) {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
