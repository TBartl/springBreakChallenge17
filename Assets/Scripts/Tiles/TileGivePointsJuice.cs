using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGivePointsJuice : TileBasicJuice {

    public GameObject confetti;

    public void OnGivePoints() {
        // Replace this with your own juice
        this.GetComponent<Renderer>().material.color = Color.grey;
        SoundManager.S.tileGetPoints.Play();
        GameObject.Instantiate(confetti, this.transform.position + Vector3.up * .5f, Quaternion.identity);
    }

    // Feel free to override some base functions here if you want to
}
