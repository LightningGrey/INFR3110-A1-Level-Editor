using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    public List<Observer> _observers = new List<Observer>();

    public void Notify()
    {
        for (int i = 0; i < _observers.Count; i++)
        {
            _observers[i].OnNotify();
        }
    }

    public void AddObserver(Observer _newObserver)
    {
        _observers.Add(_newObserver);
    }

    public void RemoveObserver(Observer _newObserver)
    {
        _observers.Remove(_newObserver);
    }
}
