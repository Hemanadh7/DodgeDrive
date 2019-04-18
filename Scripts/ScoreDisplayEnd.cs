using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayEnd : MonoBehaviour {

    public Text scoreAtEnd;

    private ScoreMaster scoreMaster;

	// Use this for initialization
	void Start () {
        scoreMaster = GameObject.FindObjectOfType<ScoreMaster>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreAtEnd.text = scoreMaster.scoreToDisplayInt.ToString();
        if (scoreMaster.scoreToDisplayInt > PlayerPrefsManager.GetHighScore())
        {
               PlayerPrefsManager.SetHighScore(scoreMaster.scoreToDisplayInt);
        }
	}
}
