using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAtRelativePoint : MonoBehaviour {
    public float force;
    public Vector3 relative;

	// Use this for initialization
	void Start () {
        Vector3 explosionPosition = this.transform.position + relative;
		foreach (Rigidbody rb in this.GetComponentsInChildren<Rigidbody>()) {
            rb.AddExplosionForce(force, explosionPosition, 100f);
        }
	}
}
