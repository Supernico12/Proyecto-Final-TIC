using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMaster : MonoBehaviour {

	uint bankID;

	// Use this for initialization
	protected void LoadBank () {
		AkSoundEngine.LoadBank ("Test", AkSoundEngine.AK_DEFAULT_POOL_ID, out bankID);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayEvent(string eventName){
		AkSoundEngine.PostEvent (eventName, gameObject);
		Debug.Log ("Evento iniciado ");
	}

	public void StopEvent (string eventname, int fadeout){
		uint eventID;
		eventID = AkSoundEngine.GetIDFromString (eventname);
		AkSoundEngine.ExecuteActionOnEvent (eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
		Debug.Log ("Evento parado");
	}

	public void PauseEvent (string eventname, int fadeout){
		uint eventID;
		eventID = AkSoundEngine.GetIDFromString (eventname);
		AkSoundEngine.ExecuteActionOnEvent (eventID, AkActionOnEventType.AkActionOnEventType_Pause, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
		Debug.Log ("Evento parado");
	}

	public void ResumeEvent (string eventname, int fadeout){
		uint eventID;
		eventID = AkSoundEngine.GetIDFromString (eventname);
		AkSoundEngine.ExecuteActionOnEvent (eventID, AkActionOnEventType.AkActionOnEventType_Resume, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
		Debug.Log ("Evento parado");
	}
}
