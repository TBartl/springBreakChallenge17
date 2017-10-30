using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerJuice : MonoBehaviour {

	PlayerJuice juice;

	void Awake() {
		juice = this.GetComponent<PlayerJuice>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			juice.enabled = !juice.enabled;
		}
	}
}
