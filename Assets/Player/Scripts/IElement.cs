using System.Collections.Generic;

namespace Player.Scripts
{
    public interface IElement
    {
        object ElementalReaction(IElement other);
        object ElementalDebuffs(IElement other);
        bool ElementalResonance(List<IElement> team);
    }
}