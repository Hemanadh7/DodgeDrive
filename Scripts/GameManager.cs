using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject endPanel;

    //private ScoreMaster scoreMaster;
    private PlayerFollower playerFollower;
    private Player player;
    private bool endActive;

	// Use this for initialization
	void Start () {
        endPanel.SetActive(false);
        playerFollower = GameObject.FindObjectOfType<PlayerFollower>();
        //scoreMaster = GameObject.FindObjectOfType<ScoreMaster>();
        player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerFollower.playerDead)
        {
            endPanel.SetActive(true);
            endActive = true;
        }
        if (playerFollower.playerDead && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            playerFollower.playerDead = false;
            player.playerHit = false;
            player.fuelEmpty = false;
        }
        if (endActive && Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Menu");
            endActive = false;
        }
	}
}
