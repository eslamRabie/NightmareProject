using UnityEngine;

namespace Levels.Scripts
{
    [CreateAssetMenu(fileName = "LevelDifficultySO", menuName = "LevelDifficultySO", order = 0)]
    public class LevelDifficultySO : ScriptableObject
    {
        [SerializeField][Range(1, 100)] public int playerElementPercentage;
        [SerializeField] public float averageDistanceToMysteryBox;
        [SerializeField][Range(0, 1)] public float pathCostExtraMarginPercentage;
        [SerializeField] public int numberOfHiddenEnemies;
    }
}