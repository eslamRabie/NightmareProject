using UnityEngine;

namespace Levels.Scripts
{
    [CreateAssetMenu(fileName = "GridInfoSO", menuName = "GridInfoSO", order = 0)]
    public class GridInfoSO : ScriptableObject
    {
        [SerializeField] public int UnitGridSize;
        [SerializeField] public Vector2 gridSize;
    }
}