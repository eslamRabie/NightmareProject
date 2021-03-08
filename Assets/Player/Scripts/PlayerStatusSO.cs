using UnityEngine;

namespace Player.Scripts
{
    [CreateAssetMenu(fileName = "PlayerStatus", menuName = "PlayerStatus", order = 0)]
    public class PlayerStatusSO : ScriptableObject
    {
        [SerializeField] private IElement mainElement;
        [SerializeField] private PlayerElementalPowerLevels powerLevels;
        [SerializeField] private Vector3Int location;
        [SerializeField] private float playerSpeed;

    }
}