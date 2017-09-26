using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A Basic Tile is one that can't be destroyed and doesn't spawn objects
// This includes the ground, the pipe walls, and square blocks
// While the player doesn't interact with them that much outside of collision, I've still gone ahead and exposed
// Functionality for them in case you want to do something like have them light up when something steps on it.

public class TileBasicJuice : MonoBehaviour {

    //int entityCount = 0;
    public AnimationCurve jiggleCurve;
    Vector3 originalPos;

    void Start() {
        originalPos = this.transform.position;
    }

    public virtual void OnSteppedOn() {
        //entityCount += 1;
        //if (entityCount == 1) {
        //    this.GetComponent<MeshRenderer>().material.color = new Color(.8f, .8f, .8f);
        //}
    }

    public virtual void OnSteppedOff() {
        //entityCount -= 1;
        //if (entityCount == 0) {
        //    this.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
        //}
    }

    public virtual void OnBonkedOn() {
        StartCoroutine(Jiggle());
    }

    public virtual void OnBonkedOff() {
    }

    protected virtual IEnumerator Jiggle() {
        Vector3 targetPos = originalPos + Vector3.up * .3f;
        float length = 1;
        for (float t = 0; t < length; t+= Time.deltaTime) {
            float p = t / length;
            this.transform.position = Vector3.Lerp(originalPos, targetPos, p);
        }
        yield return null;
        this.transform.position = originalPos;
    }

}
