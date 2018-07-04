using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAndShoot : MonoBehaviour {
    private static LockAndShoot Instance;
    public static LockAndShoot GetInstance() {
        return Instance;
    }
    public GameObject Crosshair;
    public GameObject Target;
    public bool Lock;


    public void Awake() {
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void  LockTarget() {

    }

    public void DisLockTarget() {

    }
}
