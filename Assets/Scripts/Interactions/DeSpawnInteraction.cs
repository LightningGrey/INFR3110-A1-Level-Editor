using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeSpawnInteraction : I_Interactions
{
    private DeSpawnReceiver receiver;
    private GameObject gameObject;

    public DeSpawnInteraction(GameObject gameObject) {
        this.gameObject = gameObject;
    }
    // Start is called before the first frame update
    public void undo()
    {
        receiver.undo(gameObject);
    }

    // Update is called once per frame
    public void redo()
    {
        receiver.redo(gameObject);   
    }
}