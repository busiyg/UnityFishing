using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    private int Score=0;
    public int score { set { Score = value; UpdateScore(); } get { return Score; } }

    public Text ScoreText;
	// Use this for initialization
	void Start () {
		
	}

    public void UpdateScore() {
        ScoreText.text = string.Format("积分:{0}", Score.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
