using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour {

	// Use this for initialization

	private Vector3 position = new Vector3 (0.0f, 0.0f, 0.0f);
	private float yRotation = 0.0f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			
		//Codigo práctica
		//**************************************//





		//**************************************//

		this.transform.rotation = Quaternion.Euler( new Vector3 (0.0f, yRotation, 0.0f));
		this.transform.position = position;
	}
}
