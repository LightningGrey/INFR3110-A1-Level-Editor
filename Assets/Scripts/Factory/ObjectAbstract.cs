using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAbstract: MonoBehaviour
{
    public GameObject prefab;
    public GameObject clone;
    public abstract GameObject spawn(Vector3 vec3);
    public void despawn() {
        
        Destroy(History.objects.Pop());
    }
}
