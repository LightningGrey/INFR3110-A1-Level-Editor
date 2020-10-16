using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class TranslationInteraction : I_Interactions
{
    public GameObject gameObject;
    public Vector3 position;

    public TranslationInteraction(GameObject gameObject, Vector3 pos) {
        this.gameObject = gameObject;
        this.position = pos;
    }

    // Start is called before the first frame update
    public void undo()
    {
        Vector3 pos = gameObject.transform.position;
        gameObject.transform.position = position;
        position = pos;
    }

    // Update is called once per frame
    public void redo()
    {
        Vector3 pos = gameObject.transform.position;
        gameObject.transform.position = position;
        position = pos;
    }
}
