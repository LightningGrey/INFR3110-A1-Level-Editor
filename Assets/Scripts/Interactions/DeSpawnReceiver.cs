using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawnReceiver : MonoBehaviour
{
    
    public void undo(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    public void redo(GameObject gameObject)
    {
        Instantiate(gameObject);
    }
}
