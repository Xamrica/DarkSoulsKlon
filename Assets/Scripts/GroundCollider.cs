using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    public LayerMask layer;
    public bool isOnGround = false;
    public float checkRadius = 0.5f;
    private long numberOfGrounds = 0;

    void Start()
    {
        isOnGround = false;
        numberOfGrounds = 0;
    }

    void Update()
    {
        isOnGround = Physics.CheckSphere(this.transform.position, checkRadius, layer);
    }
}
