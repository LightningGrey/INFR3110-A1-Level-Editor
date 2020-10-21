using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightObject : ObjectAbstract {
    public override GameObject spawn(Vector3 vec3) {
        return Instantiate(prefab, vec3, Quaternion.identity);
    }
}
