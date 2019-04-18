using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMaster : MonoBehaviour {

    public Text scoreText;

    private float scoreToDisplay;
    [HideInInspector]
    public int scoreToDisplayInt;
    public int scoreBooster = 1;

    private MeoterStrikeLocator obj;
    private PlayerFollower playerFollower;

	// Use this for initialization
	void Start () {
        scoreText.text = "0";
        obj = GameObject.FindObjectOfType<MeoterStrikeLocator>();
        playerFollower = GameObject.FindObjectOfType<PlayerFollower>();
        scoreToDisplay = obj.scoreMultiplier;
	}
	
	// Update is called once per frame
	void Update () {
        if (!playerFollower.playerDead)
        {
            scoreToDisplay += (5*Time.deltaTime) * scoreBooster;
            scoreToDisplayInt = (int) scoreToDisplay;
        }
        scoreText.text = scoreToDisplayInt.ToString();
	}
}
