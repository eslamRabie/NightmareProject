using System.Threading.Tasks;
using UnityEngine;

namespace Levels.Scripts.Elements
{
    public class Freeze : MonoBehaviour, IDebuff<Element>
    {
        private int freezeTimeMS = 100;
        public async void Effect(Element effector)
        {
            effector.gameObject.SetActive(false);
            await Task.Delay(freezeTimeMS);
            effector.gameObject.SetActive(true);
        }
    }
}