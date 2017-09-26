using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRT : MonoBehaviour {
    Camera mainCamera;
    RenderTexture renderTexture;

	// Use this for initialization
	void Start () {
        mainCamera = this.GetComponent<Camera>();
        renderTexture = mainCamera.targetTexture;		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
            if (mainCamera.targetTexture == null)
                mainCamera.targetTexture = renderTexture;
            else
                mainCamera.targetTexture = null;
        }
	}
}
