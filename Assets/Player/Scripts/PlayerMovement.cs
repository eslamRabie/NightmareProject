using System.Collections;
using System.Collections.Generic;
using Levels.Scripts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement
{

    private Queue<Vector3> _movementQueue;

    private Vector3 target;

    public PlayerMovement(Vector3 position)
    {
        target = position;
        _movementQueue = new Queue<Vector3>();
    }
    
    public void UpdateMovementVector(Vector2 movementVector)
    {
        if (movementVector != Vector2.zero)
        {
            _movementQueue.Enqueue(new Vector3(movementVector.x, 0, movementVector.y));
        }

    }
    
    public Vector3 MovePlayer(Vector3 position, int unitMove, bool valid)
    {
        if (!valid) target = position;
        if(Vector3.Distance(position, target) < 0.2)
            if (_movementQueue.Count > 0)
                target = target + (_movementQueue.Dequeue() * unitMove);
        return target;
    }
}
