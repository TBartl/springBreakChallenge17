using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBreakableJuice : TileBasicJuice {

    public GameObject corpse;

    public override void OnBonkedOn() {
        base.OnBonkedOn();
        SoundManager.S.tileBroken.Play();
        GameObject.Instantiate(corpse, this.transform.position, Quaternion.identity);
    }
    
    // Feel free to override some base functions here if you want to
}
