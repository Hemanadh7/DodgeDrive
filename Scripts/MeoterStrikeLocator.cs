using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MeoterStrikeLocator : MonoBehaviour {

    public GameObject demoObject;
    public Text warmUp;
    public GameObject blueOrb;
    public GameObject pinkOrbs;
    public float shieldTime = 10f;
    public float scoreBoosterTime = 15f;

    public int difficultyChanger;
    //public int onStartMenu;
    public float scoreMultiplier = 5;

	// Use this for initialization
	void Start () {
        warmUp.enabled = true;
        InvokeRepeating("ReleaseShield", 0.0f, 40f);
        InvokeRepeating("ReleaseScoreBooster", 0.0f, 60f);
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            difficultyChanger = 95;
        }
        else if (Time.timeSinceLevelLoad < 25f)
        {
            scoreMultiplier = 5;
            difficultyChanger = 98;
        }
        else if (Time.timeSinceLevelLoad > 26f && Time.timeSinceLevelLoad < 300f)
        {
            warmUp.enabled = false;
            scoreMultiplier = 15;
            difficultyChanger = 95;
        }
        else if (Time.timeSinceLevelLoad > 301f)
        {
            scoreMultiplier = 25;
            difficultyChanger = 85;
        }

        if (Random.Range(1,100) > difficultyChanger)
        {
            Fire();
        }
	}

    void Fire()
    {
        Vector3 pos = Random.onUnitSphere * 25f;
        GameObject go = Instantiate(demoObject, pos, Quaternion.identity) as GameObject;
        //Debug.Log(pos);
        Destroy(go, 5f);
    }

    void ReleaseShield()
    {
        Vector3 pos = Random.onUnitSphere * 25f;
        GameObject go = Instantiate(blueOrb, pos, Quaternion.identity) as GameObject;
        Debug.Log(go.transform.name);
        Destroy(go, 10.0f);
    }

    void ReleaseScoreBooster()
    {
        Vector3 pos = Random.onUnitSphere * 25f;
        GameObject go = Instantiate(pinkOrbs, pos, Quaternion.identity) as GameObject;
        Debug.Log(go.transform.name);
        Destroy(go, 10.0f);
    }
}
