using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    //Variables
    public Slider fuelSlider;
    public float Speed = 10f;
    public float rotateAngle = 10;
    public ParticleSystem[] carExplosionParticles;
    public AudioClip explodeSound;
    [HideInInspector]
    public bool playerHit = false;
    [HideInInspector]
    public bool fuelEmpty = false;
    public GameObject shield;

    private AudioSource audioSource;
    private MeoterStrikeLocator powerUpSpawn;
    private ScoreMaster scoreMaster;
    private bool shieldActive = false;
    private bool boosterActive = false;

    //Methods
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        powerUpSpawn = GameObject.FindObjectOfType<MeoterStrikeLocator>();
        scoreMaster = GameObject.FindObjectOfType<ScoreMaster>();
        shield.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (shieldActive)
        {
            powerUpSpawn.shieldTime -= Time.deltaTime;
            //Debug.Log(powerUpSpawn.shieldTime);
            if (powerUpSpawn.shieldTime <= 0)
            {
                shield.SetActive(false);
                shieldActive = false;
            }
        }

        if (boosterActive)
        {
            powerUpSpawn.scoreBoosterTime -= Time.deltaTime;
            if (powerUpSpawn.scoreBoosterTime <= 0)
            {
                scoreMaster.scoreBooster = 1;
                boosterActive = false;
            }
        }
	}

    //Player PowerUps Logic starts here!
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fuel")
        {
            FuelBehaviour fuelObj = other.GetComponent<FuelBehaviour>();
            //Debug.Log("Fuel picked!");
            fuelSlider.value += fuelObj.fuelIncrease; 
            Destroy(other.gameObject);
        }

        if (!shieldActive && other.tag == "Shield")
        {
            //Debug.Log("Shield Picked!!");
            powerUpSpawn.shieldTime = 10f;
            shield.SetActive(true);
            shieldActive = true;
            Destroy(other.gameObject);
        }

        if (!boosterActive && other.tag == "ScoreBooster")
        {
            powerUpSpawn.scoreBoosterTime = 15f;
            scoreMaster.scoreBooster = 2;
            boosterActive = true;
            Destroy(other.gameObject);
        }
    }
    
    //PowerUp logic ends here! 

    public void DestroyPlayer()
    {
        Speed = 0f;
        rotateAngle = 0f;
        audioSource.clip = explodeSound;
        audioSource.Play();
        carExplosionParticles[0].Play();
        carExplosionParticles[1].Play();
        carExplosionParticles[2].Play();
        Destroy(transform.gameObject, 4f);
        playerHit = true;
    }

    private void FixedUpdate()
    {   
        fuelSlider.value -= (float) 1.5*Time.deltaTime;
        if (fuelSlider.value <= 0 && !fuelEmpty)
        {
            DestroyPlayer();
            fuelEmpty = true;
        }
        
        transform.Translate(Vector3.forward * Speed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0,-rotateAngle,0), Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, rotateAngle, 0), Space.Self);
        }
    }
}
