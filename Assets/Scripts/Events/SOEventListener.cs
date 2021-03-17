using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class SOEventListener : MonoBehaviour
{
    public EventSO eventSO;
    public UnityEvent response;
    private void OnDisable()
    {
        eventSO.unRegister(this);
    }
    public virtual void onEventRaised()
    {
        response.Invoke();
    }
}
