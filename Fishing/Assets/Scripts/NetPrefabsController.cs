using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NetPrefabsController : MonoBehaviour {
    public int Damage;
    public int size;
    public BoxCollider2D NetCollider;
	// Use this for initialization
	void Start () {
        transform.DOScale(new Vector3(size, size, size),0.3f).OnComplete(()=> {
            NetCollider.enabled = true;
            transform.DOScale(new Vector3(size * 0.8f, size * 0.8f, size * 0.8f), 0.3f).OnComplete(()=> {
                transform.DOScale(new Vector3(size, size, size), 0.3f).OnComplete(()=> {
                
                    DestoryNet();
                });
            });
        });
	}

	void Update () {
		
	}

    public void DestoryNet() {
        Destroy(gameObject,0.5f);
    }

    
}
