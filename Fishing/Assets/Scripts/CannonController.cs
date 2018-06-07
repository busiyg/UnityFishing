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
    public GameObject LaserPrefabs;

    public Transform BulletStartPos;

    void Start() {
        if (CannonModels != null) {
            CurrentCannon = CannonModels[0];
        }
    }

    public void UpdateUI() {
        if (CurrentCannon.CannonSprite!=null) {
            render.sprite = CurrentCannon.CannonSprite;
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
        if (CurrentCannon.type==CannonType.bullet) {
            var bullet = Instantiate(BulletPrefabs, BulletStartPos);
            bullet.GetComponent<BulletController>().InitBullet(CurrentCannon);
        }

        if (CurrentCannon.type == CannonType.laser) {
            var laser = Instantiate(LaserPrefabs, BulletStartPos);
            laser.GetComponent<LaserPrefabsController>().Damage = CurrentCannon.damage;
            laser.GetComponent<LaserPrefabsController>().size = CurrentCannon.Size;
            BGController.GetInstance().CurrentLaser = laser;
        }
        
       
    }


}
