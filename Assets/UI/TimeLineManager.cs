using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeLineManager : MonoBehaviour {

    [SerializeField] private Reader reader;
    [SerializeField] private Player player;
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI timeText;

    private void Update() {
        progressBar.fillAmount = (float) player.CurrentFrameIndex / (float) reader.TotalFrames;

        float time = (float)player.CurrentFrameIndex / player.Fps;

        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
       
        timeText.text = minutes + ":" + seconds;
    }
}
