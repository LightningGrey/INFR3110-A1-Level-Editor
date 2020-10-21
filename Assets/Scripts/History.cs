using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour
{
    public static Stack<I_Interactions> history = new Stack<I_Interactions>();
    public static Stack<I_Interactions> future = new Stack<I_Interactions>();
    public static Stack<GameObject> objects = new Stack<GameObject>();
    public Subject s;

    public void undo() {
        if(history.Peek() is DeSpawnInteraction) {
            s.RemoveObserver(this.GetComponent<UIManager>()._createdObject);
        }
        history.Peek().undo();
        future.Push(history.Pop());
    }

    public void redo() {
        future.Peek().redo();
        if (future.Peek() is DeSpawnInteraction) {
            s.AddObserver(this.GetComponent<UIManager>()._createdObject);
        }
        history.Push(future.Pop());
    }
}
