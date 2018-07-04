using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {
    private static TouchManager Instance;
    public static TouchManager GetInstance() {
        return Instance;
    }

    private void Awake() {
        Instance = this;
    }
    public GameObject CurrentLaser;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown() {
        if (LockAndShoot.GetInstance().Lock) {

        } else {
            GameController.GetInstance().cannonController.Onclick();
        }
      
    }

    public void OnMouseUp() {
        if (CurrentLaser != null) {
            CurrentLaser.GetComponent<LaserPrefabsController>().DestoryNet();
            CurrentLaser = null;
        }
    }
}
