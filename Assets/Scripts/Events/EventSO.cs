using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventSO : ScriptableObject
{
    List<SOEventListener> listeners = new List<SOEventListener>();
    public void register(SOEventListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }
    public void unRegister(SOEventListener listener)
    {
        listeners.Remove(listener);
    }
    public void raise()
    {
        foreach (var listener in listeners)
        {
            listener.onEventRaised();
        }
    }
}