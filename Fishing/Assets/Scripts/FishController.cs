using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FishController : MonoBehaviour {
    public bool isDead;
    public FishInfoModel FishInfo;
    public SpriteRenderer render;
    public GameObject ScoreAniPrefabs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isDead) {
            gameObject.transform.Translate(Vector3.right * FishInfo.speed);
        }
      
	}

    public void UpdateUI() {
        render.sprite = FishInfo.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag=="Net") {
            if (collision.GetComponent<NetPrefabsController>()!=null) {
                var NetComp = collision.GetComponent<NetPrefabsController>();
             
                FishInfo.HP -= NetComp.Damage;
                if (FishInfo.HP <= 0) {
                    KillFish();
                } else {
                    HitFish();
                }
            }
        
        }
    
    }

    public void HitFish() {
        render.DOColor(Color.blue, 0.2f).OnComplete(() => { render.DOColor(Color.white, 0.3f); });
    }

    public void KillFish() {
        isDead = true;
        render.DOColor(Color.red, 0.2f).OnComplete(()=> {
            GameController.GetInstance().scoreController.score += FishInfo.Score;
            Instantiate(ScoreAniPrefabs,transform.position,Quaternion.identity);
            Destroy(gameObject); });
    }



    
}
