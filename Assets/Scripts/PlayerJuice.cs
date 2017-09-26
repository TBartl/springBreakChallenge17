using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modify this as much as you want
public class PlayerJuice : MonoBehaviour {
    Player player;
    bool stretching = false;
    bool squashing   = false;
    public GameObject pivot;

    void Awake() {
        player = this.GetComponent<Player>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame, use this for anything you need to persistently update
    // For example, if your animation depends on the player speed set that here.
	void Update () {
        // Here are some variables you may want to use
        
        if (player.GetIsGrounded() == false && stretching == false)
            pivot.transform.localScale = GetStretchAmount();
        else if (squashing == false)
            pivot.transform.localScale = Vector3.one;
    }

    // All of the functions below are called by other scripts

    public void OnJump() {
        SoundManager.S.playerJump.Play();
        StartCoroutine(StartJumpStretch());
    }

    public void OnJumpOffEnemy() {
        OnJump(); //Just use OnJump's juice unless you want to do something special off of an enemy
        // But consider doing that in either GameManagerJuice or EnemyJuice
    }

    // When the player hits any tile with their head
    public void OnHitHead() {
        SoundManager.S.playerHitHead.Play();
    }

    public void OnLanded() {
        SoundManager.S.playerLanded.Play();
        StartCoroutine(HitGroundSquash());
    }

    public void OnCollectedPowerup() {
        // Only mess with this if you are changing the player when you grab a powerup
        // Otherwise do it in GameManagerJuice or CollectableJuice
    }

    public void OnDied(bool sourceIsEnemy) {
        if (sourceIsEnemy) { //Ran into enemy

        } else { //Fell in death zone

        }
        SoundManager.S.playerDied.Play();
    }

    public void OnCompletedLevel() {

    }

    IEnumerator StartJumpStretch() {
        stretching = true;
        float time = .1f;
        Vector3 original = pivot.transform.localScale;
        for (float f = 0; f < time; f += Time.deltaTime) {
            if (player.GetIsGrounded() == true) {
                stretching = false;
                break;
            }
            float percent = f / time;
            pivot.transform.localScale = Vector3.Lerp(original, GetStretchAmount(), percent);
            yield return null;
        }
        stretching = false;
    }

    IEnumerator HitGroundSquash() {
        squashing = true;
        float time = .25f;
        Vector3 original = pivot.transform.localScale;
        Vector3 lowestPoint = new Vector3(1 + .6f, 1 - .6f, 1);
        Vector3 regularPoint = new Vector3(1, 1, 1);
        for (float f = 0; f < time; f += Time.deltaTime) {
            if (player.GetIsGrounded() == false) {
                squashing = false;
                break;
            }
            if (f <= time / 2f) {
                float percent = f / (time / 2f);
                pivot.transform.localScale = Vector3.Lerp(original, lowestPoint, percent);
            }
            else {
                float percent = (f - time / 2f) / (time / 2f);
                pivot.transform.localScale = Vector3.Lerp(lowestPoint, regularPoint, percent);
            }
            yield return null;
        }
    }

    Vector3 GetStretchAmount() {
        float amountToStrech = Mathf.Abs(player.GetVelocity().y) / player.initialJumpVelocity;
        return new Vector3(1 - .4f * amountToStrech, 1 + .4f * amountToStrech, 1);
    }
}
