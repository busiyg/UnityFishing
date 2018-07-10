using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTeamController : MonoBehaviour {
    public float  MoveSpeed;
    public int TeamID;
    public List<Transform> Trans;

	// Use this for initialization
	void Start () {
		
	}

    public void InitFishs(List<int> fishs) {
        if (fishs.Count== Trans.Count) {
            var fishManager = FishManager.GetInstance();
            for (int i=0; i< fishs.Count;i++) {
                if (Trans[i]!=null) {
                    var fish = fishManager.CreatFishByID(fishs[i]);
                    if (fish!=null) {
                        fish.transform.SetParent(Trans[i]);
                        fish.transform.position = Trans[i].position;
                    }
                   
                }
            }
        }
     
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 10) {
            Destroy(gameObject);
          
        } else {
            gameObject.transform.Translate(Vector3.right * MoveSpeed);
        }
      
    }
}
