using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LittleTeamController : MonoBehaviour {
    public float Speed;
    public int ID;
    public List<Transform> Trans;
    public List<GameObject> Fishes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveByPath(List<Vector3> transList) {
        var trans = transList.ToArray();
        gameObject.transform.DOLocalPath(trans, 1/Speed, PathType.CatmullRom, PathMode.Sidescroller2D, 1).SetLookAt(0.01f).OnComplete(() => {
            Destroy(gameObject);
        });
    }

    public void InitFish(int FishID) {
        var fishManager = FishManager.GetInstance();
        for (int i=0;i< Trans.Count;i++) {
            var fish = fishManager.CreatFishByID(FishID);
            fish.transform.position = Trans[i].position;
            fish.transform.rotation = Trans[i].rotation;
            fish.transform.SetParent(gameObject.transform);
            Fishes.Add(fish);
        }
    }
}
