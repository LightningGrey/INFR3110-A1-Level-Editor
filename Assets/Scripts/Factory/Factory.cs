using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Factory : MonoBehaviour
{
    private ObjectAbstract[] objects =  new ObjectAbstract[7] { new PlayerObject(), new BricksObject(), new WagonObject(), new Rock1Object(),
                                                                new Rock2Object(), new PointLightObject(), new SpotLightObject() };
    void Start() {
        for (int i = 0; i < 7; i++) {
            objects[i].prefab = this.gameObject.GetComponent<UIManager>().objects[i];
        }
    }

    public GameObject createObject(int id, Vector3 vec3)
    {
        return objects[id].spawn(vec3);
    }
}
