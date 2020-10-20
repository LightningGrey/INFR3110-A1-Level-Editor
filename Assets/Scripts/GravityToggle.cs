using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySetting : Observer
{
    private Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnNotify()
    {
        GravityToggle(rb);
    }

    public void GravityToggle(Rigidbody rb)
    {
        rb.useGravity = !rb.useGravity;
    }
}
