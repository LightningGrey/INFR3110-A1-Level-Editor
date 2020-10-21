using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour
{
    public static Stack<I_Interactions> history = new Stack<I_Interactions>();
    public static Stack<I_Interactions> future = new Stack<I_Interactions>();
    public static Stack<GameObject> objects = new Stack<GameObject>();

    public void undo() {
        history.Peek().undo();
        future.Push(history.Pop());
    }

    public void redo() {
        future.Peek().redo();
        history.Push(future.Pop());
    }
}
