using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour {
    private static FishManager Instance;
    public List<FishInfoModel> FishModels;
    public GameObject FishePrefab;
    public List<FishTeamController> FishTeams;

    public static FishManager GetInstance() {
        return Instance;
    }

    private void Awake() {
        Instance = this;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public GameObject CreatFishByID(int ID) {
        foreach (var obj in FishModels) {
            if (ID==obj.fishType) {
                var fish = Instantiate(FishePrefab);
                fish.GetComponent<FishController>().InitFish(obj);
                return fish;
                break;
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

    public void TestInitTeam(int id) {
        List<int> fishs = new List<int>() {1,1,1,1,1,1,1,1,2,2,2,3,2,2,2,1,1,1,1,1,1,1,1,1,1};
        InitFishTeam(id, fishs);

    }
}
