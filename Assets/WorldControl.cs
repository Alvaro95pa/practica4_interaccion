using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour
{

    public float speed = 1.0f;
    public float yawSpeed = 10.0f;

    // Use this for initialization

    private Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
    private float yRotation = 0.0f;
    private Vector3 myPosition = new Vector3(0.0f, 0.0f, 0.0f);

    void Start()
    {
        position += Vector3.down; //Desplazamos el mundo un (-1) por debajo de la cámara
    }

    // Update is called once per frame
    void Update()
    {

        //Codigo práctica
        //**************************************//

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float t = Time.deltaTime;

        // 1. Acumula rotación total
        yRotation += (-horizontal) * yawSpeed * t;

        // 2. Rotar vector forward original
        Vector3 forwardVector;
        forwardVector = Quaternion.AngleAxis(-yRotation, Vector3.up) * Vector3.forward;

        // 3. Acumular a la posición actual el desplazamiento según el
        // movimiento vertical y la rotación actual
        myPosition += (-forwardVector) * vertical * speed * t;

        // 4. Roto la posición (x, y) para devolverlo a la dirección del forward original,
        // para poder aplicar el pipeline habitual de rotación + traslación
        position = myPosition;
        position = Quaternion.AngleAxis(yRotation, Vector3.up) * position;

        //**************************************//

        this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, yRotation, 0.0f));
        this.transform.position = position;
    }
}
