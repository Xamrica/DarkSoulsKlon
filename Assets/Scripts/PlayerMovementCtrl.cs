using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCtrl : MonoBehaviour
{
    private Rigidbody playerRb;
    
    public float speed;
    public GameObject Kamera;
    public float jumpHeight = 10.0f;
    public float timeBetweenJumps = 0.1f;
    public Collider groundCollider;

    private float timeSinceLastJump;
    private float moveInputHorizontal;
    private float moveInputVertical;
    private float moveInputJump;
    private GroundCollider coll;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.useGravity = true;
        timeSinceLastJump = 1;
        coll = this.GetComponentInChildren<GroundCollider>();
    }

    

    // Update is called once per frame
    void Update()
    {
        moveInputHorizontal = Input.GetAxisRaw("Horizontal");
        moveInputVertical = Input.GetAxisRaw("Vertical");
        moveInputJump = Input.GetAxisRaw("Jump");
        //Debug.Log(moveInputJump);
        timeSinceLastJump += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector3 v = Kamera.transform.eulerAngles;
        Vector2 richtungsVector = new Vector3(-1 * Mathf.Cos(v.x * Mathf.Deg2Rad) * Mathf.Sin(v.y * Mathf.Deg2Rad), -1 * Mathf.Cos(v.x * Mathf.Deg2Rad) * Mathf.Cos(v.y * Mathf.Deg2Rad));
        v.y = v.y - 90;
        Vector2 richtungsVector2 = new Vector3(-1 * Mathf.Cos(v.x * Mathf.Deg2Rad) * Mathf.Sin(v.y * Mathf.Deg2Rad), -1 * Mathf.Cos(v.x * Mathf.Deg2Rad) * Mathf.Cos(v.y * Mathf.Deg2Rad));
        if (timeSinceLastJump > timeBetweenJumps && moveInputJump != 0 && coll.isOnGround)
        {
            playerRb.velocity = playerRb.velocity + Vector3.up * jumpHeight * moveInputJump;
            timeSinceLastJump = 0;  
        }
        if (coll.isOnGround)
        {
            playerRb.velocity = new Vector3(0, playerRb.velocity.y, 0) + Vector3.Normalize(new Vector3(richtungsVector2.x * moveInputHorizontal - richtungsVector.x * moveInputVertical, 0, richtungsVector2.y * moveInputHorizontal - richtungsVector.y * moveInputVertical)) * speed;
        }
    }
}
