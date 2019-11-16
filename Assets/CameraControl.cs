using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float yRotation{
	  get{
			return this.transform.rotation.eulerAngles.y;
	  }
	}

	public float zRotation{
		get{
			return this.transform.rotation.eulerAngles.z;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
