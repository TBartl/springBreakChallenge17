using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Player player;
    public Vector2 horizontalBounds;
    public float lerpPower;

    public float aheadDistance;

    float realXPosition;

    void Start() {
        realXPosition = this.transform.position.x;
    }

	void LateUpdate () {
        if (player) {
            realXPosition = Mathf.Lerp(
                realXPosition,
                Mathf.Clamp(player.transform.position.x + player.GetVelocity().x / player.maxHorizontalSpeed * aheadDistance, horizontalBounds.x, horizontalBounds.y),
                Time.deltaTime * lerpPower);

            float xCam = realXPosition;
            this.transform.position = new Vector3(xCam, transform.position.y, transform.position.z);
        }
    }
}
