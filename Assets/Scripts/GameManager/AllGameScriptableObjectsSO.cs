using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    [CreateAssetMenu(fileName = "AllGameScriptableObjectsSO", menuName = "AllGameScriptableObjectsSO", order = 0)]
    public class AllGameScriptableObjectsSO : ScriptableObject
    {
        [SerializeField] public List<ScriptableObject> SOList;
    }
}