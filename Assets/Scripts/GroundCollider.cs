using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    public bool isOnGround = false;
    private long numberOfGrounds = 0;

    void Start()
    {
        isOnGround = false;
        numberOfGrounds = 0;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isOnGround = true;
            numberOfGrounds++;
        }
        Debug.Log("collision enter. Layer: " + other.gameObject.layer + "  i: " + numberOfGrounds);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            numberOfGrounds--;
            if (numberOfGrounds == 0)
            {
                isOnGround = false;
            }
        }
        Debug.Log("collision exit. Layer: " + other.gameObject.layer + "  i: " + numberOfGrounds);
    }
}
