using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCreater : MonoBehaviour {
    public List<FishInfoModel> FishModels;
    public GameObject FishePrefab;
    public float Timer;
    public float interval;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        if (Timer > interval) {
            InitFish();
            Timer = 0;
        }
	}

    public void InitFish() {
        var RandomY = Random.Range(-4, 4);
        var RandomFish = FishModels[Random.Range(0, FishModels.Count)];
        var pos = new Vector3(gameObject.transform.position.x,RandomY,0);
        var obj =Instantiate(FishePrefab, pos,gameObject.transform.rotation);
       
        //obj.GetComponent<FishController>().FishInfo = copy;
        obj.GetComponent<FishController>().InitFish(RandomFish);
    }
}
