using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCtrl : MonoBehaviour
{
    private Rigidbody playerRb;
    
    public float speed;
    public GameObject Kamera;

    private float moveInputHorizontal;
    private float moveInputVertical;
    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInputHorizontal = Input.GetAxisRaw("Horizontal");
        moveInputVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 v = Kamera.transform.eulerAngles;
        Vector2 richtungsVector = new Vector3(-1 * Mathf.Cos(v.x * Mathf.Deg2Rad) * Mathf.Sin(v.y * Mathf.Deg2Rad), -1 * Mathf.Cos(v.x * Mathf.Deg2Rad) * Mathf.Cos(v.y * Mathf.Deg2Rad));
        v.y = v.y - 90;
        Vector2 richtungsVector2 = new Vector3(-1 * Mathf.Cos(v.x * Mathf.Deg2Rad) * Mathf.Sin(v.y * Mathf.Deg2Rad), -1 * Mathf.Cos(v.x * Mathf.Deg2Rad) * Mathf.Cos(v.y * Mathf.Deg2Rad));


        playerRb.velocity = Vector3.Normalize(new Vector3(richtungsVector2.x * moveInputHorizontal - richtungsVector.x * moveInputVertical, playerRb.velocity.y, richtungsVector2.y * moveInputHorizontal - richtungsVector.y * moveInputVertical)) * speed;
    }
}
