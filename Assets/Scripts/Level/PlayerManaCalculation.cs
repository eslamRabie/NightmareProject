using UnityEngine;

namespace Level
{
    public class PlayerManaCalculation
    {
        public float CalculateMana(GameObject player, GameObject masteryBox, GameGrid grid,
            float pathCostExtraMarginPercentage, float averageDistanceToMysteryBox)
        {
            float mana = 0.0f;
            return mana + (mana * pathCostExtraMarginPercentage);
        }
    }
}
