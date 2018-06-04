using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BGController : MonoBehaviour {
    public List<Sprite> BGSprites;
    public SpriteRenderer CurrentRender;
    public SpriteRenderer TransitionRender;
    public bool IsChangeing;
    private float Timer;
    public float Interval;

    void Start () {
        CurrentRender.sprite = BGSprites[0];
        TransitionRender.enabled = false;
    }

    private void Update() {
        Timer += Time.deltaTime;
        if (Timer>Interval) {
            TestBG();
            Timer = 0;
        }
    }

    public void TestBG() {
        if (IsChangeing==false) {
            IsChangeing = true;
            var currentBG = BGSprites.IndexOf(CurrentRender.sprite);
            if (currentBG < BGSprites.Count - 1) {
                ChangeBG(currentBG + 1);
            } else {
                ChangeBG(0);
            }         
        }    
    }

    public void ChangeBG(int Num) {
        TransitionRender.sprite = CurrentRender.sprite;
        TransitionRender.enabled = true;
        CurrentRender.sprite = BGSprites[Num];
        TransitionRender.DOFade(0,1).OnComplete(()=> {
            TransitionRender.enabled = false;
            TransitionRender.color = new Color(1,1,1,1);
            IsChangeing = false;

        });
    }

    public void OnMouseDown() {
        GameController.GetInstance().cannonController.Onclick();
    }
}
