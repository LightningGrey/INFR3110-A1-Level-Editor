using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : Observer
{
    public int ID;
    public GameObject _gameObject;
    public Rigidbody rb;

    public Object(GameObject createdObject)
    {
        _gameObject = createdObject;
        rb = _gameObject.GetComponent<Rigidbody>();
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
