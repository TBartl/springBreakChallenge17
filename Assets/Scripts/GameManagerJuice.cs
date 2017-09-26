using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Modify this as much as you want
public class GameManagerJuice : MonoBehaviour {

    public Text timeText;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame, use this for anything you need to persistently update
    void Update() {
        if (!GameManager.S.gameEnding) {
            string time = Time.timeSinceLevelLoad.ToString("0.00");
            while (time.Length < 6) {
                time = "0" + time;
            }
            timeText.text = "Time " + time;
        }
    }

    public void OnPlayerDied() {

    }

    public void OnLevelComplete() {
        SoundManager.S.levelComplete.Play();
    }

    public void OnPointsChanged(int change) {
        if (change == -1) {
            // A second passed
            SoundManager.S.timerTick.Play();
        }
        else {
            // You may find handling these in different scripts more productive
            if (change == 5) {
                // Player hit block that gives points (Use TileGivePointsJuice instead)
            }
            // You may want to handle these not here
            if (change == 10) {
                // Player killed an enemy (Use EnemyJuice instead)
            }
            // You may want to handle these not here
            if (change == 25) {
                // Player grabbed a collectable (Use CollectableJuice instead)
            }
        }
    }

    
}