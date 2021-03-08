using UnityEngine;

namespace Levels.Scripts
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class GridInfoSO : ScriptableObject
    {
        [SerializeField] public int UnitGridSize;
        [SerializeField] public Vector2 gridSize;
    }
}