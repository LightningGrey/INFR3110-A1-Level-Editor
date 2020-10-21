using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeSpawnInteraction : I_Interactions
{
    private Vector3 vec3;
    private ObjectAbstract obj;

    public DeSpawnInteraction(ObjectAbstract obj, Vector3 vec3) {
        this.obj = obj;
        this.vec3 = vec3;
    }
    // Start is called before the first frame update
    public void undo()
    {
        obj.despawn();
    }

    // Update is called once per frame
    public void redo()
    {
        obj.spawn(vec3);
    }
}