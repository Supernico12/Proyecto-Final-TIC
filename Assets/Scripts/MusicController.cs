using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : AudioMaster
{
    public LevelManager level;
    public EnemyDamage spiderShoot;
    public PlayerFighting playershoot;
    public SettingsMenu volumen;

    CharacterStats character;

    #region Singleton

    public static  MusicController instnce;
    void Awake()
    {
        instnce = this;
    }
#endregion

    // Use this for initialization
    void Start()
    {
        character = PlayerManager.instance.player.GetComponent<CharacterStats>();

		//Cargar el soundbank
		LoadBank();

        PlayEvent("Play_Corazon"); //Comienzan a sonar los latidos del corazon (en realidad no, porque comienzan a sonar cuando la vida es menor que 50

       //Music of Current Level
		if (level.index == 0) {
			//PlayEvent ("Play_Menu");
		} 
		else if (level.index == 1) {
            //StopEvent("Play_Menu", 2);
            StopEvent("Play_Menu", 2);

			PlayEvent("Play_Patio");
	   }
       else if (level.index == 2){
	     StopEvent("Play_Patio", 2);
         PlayEvent("Play_Bunker");

       }
       else if (level.index == 3){
           PlayEvent("Play_Lab");
           StopEvent("Play_Ciudad", 2);

       }

        if (spiderShoot != null){
            spiderShoot.OnAttack += Onspidershoot;
        playershoot.OnShoot += Onplayershoot;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        AkSoundEngine.SetRTPCValue("PlayerHealth", character.currenthealth); // Cuanto menos vida tenga el personaje, mas alto sonaran los latidos del corazon
        AkSoundEngine.SetRTPCValue("GameVolume", volumen.volumeMartin);

        //Control del Latido de Corazon
        if (character.currenthealth == 0)
        {
            StopEvent("Play_Corazon", 3); //Cuando la vida del personaje llega a 0, se paran los latidos del corazon
        }

        //Control de finalización del nivel 
        if (level.lvls)
        {
            StopEvent("Play_Ciudad", 2);
            StopEvent("Play_Lab", 2);
            StopEvent("Play_Patio", 2);
            PlayEvent("Play_victory");
            level.lvls = false;
            level.levelFinished = true;
            //StartCoroutine(Paso());
            
        }
			
    }

    public void Onplayershoot()
    {
        PlayEvent("Play_Disparo" + (playershoot.arma + 1));

    }
    void Onspidershoot()
    {
        PlayEvent("Play_Laser");
    }

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Bunker") {
			StopEvent ("Play_Bunker", 2);
			PlayEvent ("Play_Ciudad");
			Destroy (col);
		}
	}
    /*
    IEnumerator Paso()
    {
        Debug.Log("Esperr 15 segundos");
        StopEvent("Play_victory", 2);
        level.levelFinished = true;

    }*/
}

