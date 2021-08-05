using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCtrl : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
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
        playerRb.velocity = new Vector3(moveInputHorizontal * speed, playerRb.velocity.y, moveInputVertical * speed);
    }
}
