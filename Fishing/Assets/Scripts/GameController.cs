using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private static GameController Instance;
    public static GameController GetInstance() {
        return Instance;
    }

    public CannonController cannonController;
    public BGController bgController;
    public ScoreController scoreController;

    private void Awake() {
        Instance = this;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LeftCannon() {
        var currentIndex = cannonController.CannonModels.IndexOf(cannonController.CurrentCannon);
        if (currentIndex>0) {
            cannonController.CurrentCannon = cannonController.CannonModels[currentIndex - 1];
            cannonController.UpdateUI();
        }
        
    }

    public void RightCaonon() {
        var currentIndex = cannonController.CannonModels.IndexOf(cannonController.CurrentCannon);
        if (currentIndex < cannonController.CannonModels.Count-1) {
            cannonController.CurrentCannon = cannonController.CannonModels[currentIndex + 1];
            cannonController.UpdateUI();
        }
    }
}
