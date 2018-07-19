using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour {
    private static FishManager Instance;
    public List<FishInfoModel> FishModels;
    public GameObject FishPrefab;
    public List<FishTeamController> FishTeams;
    public List<LittleTeamController> LittleTeams;

    public float Timer;
    public float interval;

    public static FishManager GetInstance() {
        return Instance;
    }

    private void Awake() {
        Instance = this;
    }

    // Update is called once per frame
    void Update() {
        Timer += Time.deltaTime;
        if (Timer > interval) {
            TestInitFish();
            Timer = 0;
        }

    }

    public GameObject CreatFishByID(int ID) {
        foreach (var obj in FishModels) {
            if (ID==obj.fishType) {
                var fish = Instantiate(FishPrefab);
                fish.GetComponent<FishController>().InitFish(obj);
                return fish;
                break;
            }
        }
        return null;
    }

    public GameObject ReturnLittleTeamByID(int ID) {
        foreach (var obj in LittleTeams) {
            if (ID==obj.ID) {
                return obj.gameObject;
            }
        }
        return null;
    }

    public void InitFishTeam(int teamID,List<int> fishs) {
        foreach (var obj in FishTeams) {
            if (obj.TeamID== teamID) {
                var team = Instantiate(obj.gameObject);
                team.GetComponent<FishTeamController>().InitFishs(fishs);
                break;
            }
        }
    }

    public void InitLittleTeam(int ID,int FishID,int PathID) {
        var littleTeam = Instantiate(ReturnLittleTeamByID(ID)); 
      
        var thePath = PathManager.GetInstance().ReturnPath(PathID);
        littleTeam.GetComponent<LittleTeamController>().InitFish(FishID);
        littleTeam.transform.position = thePath[0];
        littleTeam.GetComponent<LittleTeamController>().MoveByPath(thePath);
    }



    public void InitFish(int PathID,int FishID) {
        var thePath = PathManager.GetInstance().ReturnPath(PathID);
        var theFish = CreatFishByID(FishID);
        theFish.transform.position = thePath[0];
        theFish.GetComponent<FishController>().MoveByPath(thePath);
    }

    public void TestInitTeam(int id) {
        List<int> fishs = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        InitFishTeam(id, fishs);
    }

    public void TestInitFish() {
        var RandomPath =Random.Range(0, PathManager.GetInstance().BezierPath.Count);
        var RandomFish = Random.Range(0, FishModels.Count);
        InitFish(RandomPath,RandomFish);
    }

    public void TestLittleTeam() {
        var RandomLittleTeam = Random.Range(0, 2);
        var RandomFish = Random.Range(0, PathManager.GetInstance().BezierPath.Count);
        var RandomPath = Random.Range(0, 6);
        InitLittleTeam(RandomLittleTeam,RandomFish,RandomPath);
    }
}
