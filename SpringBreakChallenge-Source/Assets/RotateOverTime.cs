using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour {
    public Vector3 rotation;

    void Update() {
        this.transform.rotation *= Quaternion.Euler(rotation * Time.deltaTime);
    }
}
