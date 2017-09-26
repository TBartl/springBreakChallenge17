using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

    public float maxSpeed;
    float velocity;

	// Use this for initialization
	void Start () {
        velocity = Random.Range(-maxSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.right * velocity * Time.deltaTime;
	}
}
