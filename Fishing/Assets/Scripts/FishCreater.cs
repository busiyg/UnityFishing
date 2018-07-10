using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCreater : MonoBehaviour {
    public List<FishInfoModel> FishModels;
    public GameObject FishePrefab;
    public GameObject FishTeamPrefab;
    public float Timer;
    public float interval;
    public bool IsTeam;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        if (IsTeam) {
            if (Timer > interval*15) {
                //InitFishTeam();
                Timer = 0;
            }
        } else {
            if (Timer > interval) {
                InitFish();
                Timer = 0;
            }
        }
       
	}

    public void InitFish() {
        var RandomPath = PathManager.GetInstance().ReturnPath(Random.Range(0, 3));
        var RandomFish = FishModels[Random.Range(0, FishModels.Count)];
        var pos = RandomPath[0];
        var obj =Instantiate(FishePrefab, pos,gameObject.transform.rotation);
       
        //obj.GetComponent<FishController>().FishInfo = copy;
        obj.GetComponent<FishController>().InitFish(RandomFish);
        obj.GetComponent<FishController>().MoveByPath(RandomPath);
    }

}
