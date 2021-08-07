 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public GameObject Zielobjekt; //das Zielobjekt, welches die Kamera verfolgt. (beliebiges GameObject)
    
    public float abstand = 5.0f; // abstand der Kamera zum Zielobjekt.
    public float speedX = 2.0f; // die Geschwindigkeit der x-Achsen-Rotation
    public float speedY = 2.0f; // die Geschwindigkeit der y-Achsen-Rotation
    private float horizontaleAbweichung = 0.0f; 
    private float vertikaleAbweichung = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // addierung der Abweichungen der Maus seid letztem Tick
        horizontaleAbweichung += speedX * Input.GetAxis("Mouse X");
        vertikaleAbweichung -= speedY * Input.GetAxis("Mouse Y");
        
        //garantiert, dass man nicht mehr als 90° nach oben bzw. nach unten schauen kann.
        if (vertikaleAbweichung > 89)
        {
            vertikaleAbweichung = 89;
        }
        else if (vertikaleAbweichung < -89)
        {
            vertikaleAbweichung = -89;
        }

        //verhindert einen Zahlenüberlauf in horizontaleAbweichung.
        if (horizontaleAbweichung > 360)
        {
            horizontaleAbweichung -= 360;
        }else if (horizontaleAbweichung < -360)
        {
            horizontaleAbweichung += 360;
        }

        //Debug.Log("horizontal: " + horizontaleAbweichung + " vertikal: " + vertikaleAbweichung);
        //Debug.Log("y-pos: " + (Player.transform.position.y - Mathf.Sin(vertikaleAbweichung * Mathf.Deg2Rad) * abstand * -1));

        //setze die Rotation der Kamera auf die aktuellen Winkel:
        transform.eulerAngles = new Vector3(vertikaleAbweichung, horizontaleAbweichung, 0.0f);

        //berechnung der Position der Kamera mithilfe der Kugelparametergleichung (siehe https://www.lernhelfer.de/schuelerlexikon/mathematik-abitur/artikel/kugelgleichungen)
        transform.position = Zielobjekt.transform.position - new Vector3( -1 * Mathf.Cos(vertikaleAbweichung * Mathf.Deg2Rad) * Mathf.Sin(horizontaleAbweichung * Mathf.Deg2Rad), Mathf.Sin(vertikaleAbweichung * Mathf.Deg2Rad) ,-1 * Mathf.Cos(vertikaleAbweichung * Mathf.Deg2Rad) * Mathf.Cos(horizontaleAbweichung * Mathf.Deg2Rad)) * (abstand * -1);


    }
}
