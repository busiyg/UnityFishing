using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public CannonInfoModel cannonInfo;
    public SpriteRenderer render;
	// Use this for initialization
	void Start () {
        Invoke("InitNet",8);
	}
	
	// Update is called once per frame
	void Update () {
        BulletMove();

    }

    public void InitBullet(CannonInfoModel info) {
        cannonInfo = info;
        render.sprite = cannonInfo.BulletSprite;
        transform.SetParent(null);
    }

    public void BulletMove() {
        var ViewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (ViewPos.y >= 1) {
            transform.localEulerAngles = new Vector3(-transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }

        if (ViewPos.y <= 0) {
            transform.localEulerAngles = new Vector3(-transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }

        if (ViewPos.x >= 1) {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -transform.localEulerAngles.y, transform.localEulerAngles.z);
        }

        if (ViewPos.x <= 0) {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        transform.Translate(Vector3.forward*cannonInfo.speed);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Fish") {
            InitNet();
        }
    }

    public void InitNet() {
        var Cannon = GameController.GetInstance().cannonController;
        var net = Instantiate(Cannon.NetPrefabs, transform.position, Quaternion.identity);
        net.GetComponent<NetPrefabsController>().Damage = cannonInfo.damage;
        net.GetComponent<NetPrefabsController>().size = cannonInfo.Size;
        Destroy(gameObject);
    }

}
