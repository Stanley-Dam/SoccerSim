using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaySpeedSlider : MonoBehaviour {

    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private string speedPrefix = "Speed: ";
    [SerializeField] private string speedSuffix = "x";

    private void Awake() {
        textMesh.text = speedPrefix + player.Speed;
    }

    public void OnSlideInteract(float speed) {
        player.Speed = player.MinSpeedValue + (speed * 2);

        string playSpeed = (1 / player.Speed).ToString("0.00");
        textMesh.text = speedPrefix + playSpeed + speedSuffix;
    }
}
