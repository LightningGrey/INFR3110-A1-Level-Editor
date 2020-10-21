using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Observer : MonoBehaviour
{
    public virtual void OnNotify() { }
}
