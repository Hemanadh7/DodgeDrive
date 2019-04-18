using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour {

    public Text hiScoreText;
	
	// Update is called once per frame
	void Update () {
        hiScoreText.text = PlayerPrefsManager.GetHighScore().ToString();
	}

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(PlayerPrefsManager.HIGHSCORE_KEY);
    }
}
