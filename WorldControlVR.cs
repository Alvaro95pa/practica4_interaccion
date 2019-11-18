using UnityEngine;
using System.Collections;

public class WorldControlVR : MonoBehaviour
{

    public CameraControl cameraControl = null;
    private Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 myPosition = new Vector3(0.0f, 0.0f, 0.0f);

    private readonly float speed = 60.0f;

    private float lastVarX = 0.0f;
    private float vertical = -1.0f;
    private float lastVertical;

    void Start()
    {
        position += Vector3.down; //Desplazamos el mundo un (-1) por debajo de la cámara
    }


    void Update()
    {

        //Rotatción del eje y
        float yRotation = 0.0f;
        if (cameraControl)
        {
            yRotation = -cameraControl.yRotation;

        }

        //Shake your head
        // variación en el eje x
        float varX = 0.0f;

        // Depuración en entorno Unity
        if (cameraControl)
        {
            varX = cameraControl.zRotation;
        }
        else
        {
            // Obtención de los datos del acelerometro para correr en el dispositivo movil
            varX = Input.acceleration.x;
        }

        //Codigo práctica
        //**************************************//

        float t = Time.deltaTime;

        Vector3 forwardVector;
        forwardVector = Quaternion.AngleAxis(-yRotation, Vector3.up) * cameraControl.transform.forward;

        float resta = lastVarX - varX;

        if (Mathf.Abs(resta) > 2)
        {
            if(lastVertical < 1.0f) vertical += 0.01f;

            myPosition += (-forwardVector) * vertical * speed * t;
        }
        else
        {
            vertical = 0.0f;
        }

        position = myPosition;
        position = Quaternion.AngleAxis(yRotation, Vector3.up) * position;

        //**************************************//

        this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, yRotation, 0.0f));
        this.transform.position = position;
        lastVarX = varX;
        lastVertical = vertical;
    }
}
