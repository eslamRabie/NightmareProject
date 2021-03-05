using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public void MoveLeft(InputAction.CallbackContext context)
    {
        var x = context.ReadValue<Vector2>();
        Debug.Log(x);
    }
    public void MoveRight()
    {
        
    }
    public void MoveForward()
    {
        
    }
    public void MoveBackward()
    {
        
    }
}
