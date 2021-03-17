using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Players
{
    public class PlayerMovement
    {

        private Queue<Vector2> _movementQueue;

        private Vector3 target;
        private NavMeshHit hit;

        private float _unitMove;
        private Vector3 position;
        private float rotatingAngle = 0;


        public PlayerMovement(Vector3 position, float cellSize)
        {
            target = position;
            _movementQueue = new Queue<Vector2>();
            _unitMove = cellSize;

        }

        public void UpdateMovementVector(Vector2 movementVector)
        {
            if (movementVector != Vector2.zero)
            {
                _movementQueue.Enqueue(movementVector);
            }

        }

        public Vector3 MovePlayer(Transform playerTransform)
        {
            position = playerTransform.position;
            if (Vector3.Distance(position, target) < 0.2)
                if (_movementQueue.Count > 0)
                {
                    var tmp = _movementQueue.Dequeue();
                    if (tmp == Vector2.up)
                    {
                        target = playerTransform.position + (playerTransform.forward * _unitMove);
                    }
                    else if (tmp == Vector2.down)
                    {
                        rotatingAngle += 180;
                    }
                    else if (tmp == Vector2.left)
                    {
                        rotatingAngle -= 90;
                    }
                    else if (tmp == Vector2.right)
                    {
                        rotatingAngle += 90;
                    }
                }

            if (!NavMesh.SamplePosition(target, out hit, 1f, NavMesh.AllAreas))
            {
                target = position;
            }

            var rotationAngle = Quaternion.Euler(0, rotatingAngle, 0);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, rotationAngle,
                Time.fixedDeltaTime * 10);

            return target;
        }
    }
}