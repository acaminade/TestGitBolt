using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject objToLaunch;
	public Transform launchPoint;
	public bool launch;
	public float force = 20f;

	public GameObject cameraVisee;

	//create a trajectory predictor in code
	TrajectoryPredictor tp;
	void Start(){
		tp = gameObject.AddComponent<TrajectoryPredictor>();
		tp.drawDebugOnPrediction = true;
        tp.reuseLine = true;
		tp.iterationLimit = 600;

	}

	// Update is called once per frame
	void Update () {

		//input stuff
		if(Input.GetMouseButtonDown(0))
			Launch();
		
	}

	void LateUpdate(){
		tp.debugLineDuration = Time.unscaledDeltaTime;
		tp.Predict3D(launchPoint.position, launchPoint.forward * force, Physics.gravity);
	}

	GameObject launchObjParent;
	void Launch(){
		objToLaunch.SetActive(true);
		cameraVisee.SetActive(false);
	

	}

}
