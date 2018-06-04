using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreAniController : MonoBehaviour {
    public SpriteRenderer render;
    // Use this for initialization
    void Start() {
        var DES_Y = transform.position.y + 1;
        transform.DOLocalMoveY(DES_Y, 1).OnComplete(() => {
            render.DOFade(0, 0.3f).OnComplete(() => {
                Destroy(gameObject);
            });
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
