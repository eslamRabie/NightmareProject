using UnityEngine;

namespace Levels.Scripts
{
    public class MoonBehaviour : MonoBehaviour
    {
        //Assign a GameObject in the Inspector to rotate around
        [SerializeField] private GameObject target;

        void Update()
        {
            // Spin the object around the target at 20 degrees/second.
            transform.RotateAround(target.transform.position, Vector3.forward, 10 * Time.deltaTime);
        }
    }
}