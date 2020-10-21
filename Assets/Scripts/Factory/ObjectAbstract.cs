using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAbstract: MonoBehaviour
{
    public GameObject prefab;
    public abstract GameObject spawn(Vector3 vec3);
    public abstract void despawn();
}
