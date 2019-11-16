using UnityEngine;
using System.Collections;

public class WorldControlVR : MonoBehaviour {

	public CameraControl cameraControl = null;
	private Vector3 position = new Vector3 (0.0f, 0.0f, 0.0f);

	void Start () {
	
	}
	

	void Update () {

		//Rotatción del eje y
		float yRotation = 0.0f;
		if (cameraControl) {
			yRotation = cameraControl.yRotation;
		}

		//Shake your head
		// variación en el eje x
		float varX = 0.0f;

		// Depuración en entorno Unity
		if (cameraControl){
			varX = cameraControl.zRotation;
		}
		// Obtención de los datos del acelerometro para correr en el dispositivo movil
//		varX = Input.acceleration.x;

		//Codigo práctica
		//**************************************//





		//**************************************//

		this.transform.position = position;
	}
}
