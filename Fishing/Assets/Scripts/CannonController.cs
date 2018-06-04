using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CannonController : MonoBehaviour {
    public List<CannonInfoModel> CannonModels = new List<CannonInfoModel>();
    public CannonInfoModel CurrentCannon;

    public SpriteRenderer render;
    public GameObject NetPrefabs;
    public GameObject BulletPrefabs;
    public Transform BulletStartPos;

    void Start() {
        if (CannonModels != null) {
            CurrentCannon = CannonModels[0];
        }
    }

    public void UpdateUI() {
        if (CurrentCannon.sprite!=null) {
            render.sprite = CurrentCannon.sprite;
        }
       
    }


	void Update () {
        ChangeRotation();
    }

    public void ChangeRotation() {
        Vector3 differ = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        differ.Normalize();
        float zfloat = Mathf.Atan2(differ.y, differ.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, zfloat-90);
    }

    public void Onclick() {
        var bullet=Instantiate(BulletPrefabs,BulletStartPos);
        bullet.GetComponent<BulletController>().cannonInfo = CurrentCannon;
        bullet.transform.SetParent(null);
    }


}
