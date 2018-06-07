using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LaserPrefabsController : MonoBehaviour {
    public int Damage;
    public int size;
    public BoxCollider2D NetCollider;
    // Use this for initialization
    void Start () {
        transform.DOScaleX(size, 0.5f).OnComplete(()=> {
            NetCollider.enabled = true;
        });

       
    }

    public void DestoryNet() {
        Destroy(gameObject, 0.5f);
    }


}
