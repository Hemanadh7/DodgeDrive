using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour  {

    public const string HIGHSCORE_KEY = "Highscore";

    public static void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGHSCORE_KEY, score);
    }

    public static int GetHighScore()
    {
       return PlayerPrefs.GetInt(HIGHSCORE_KEY);
    }
}
