using System;
using UnityEngine;

namespace Elements
{
    public class Fire : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                
            }
        }
    }
}