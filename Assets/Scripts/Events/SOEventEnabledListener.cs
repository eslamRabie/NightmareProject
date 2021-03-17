using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOEventEnabledListener : SOEventListener
{
    private void OnEnable()
    {
        eventSO.register(this);
    }
}
