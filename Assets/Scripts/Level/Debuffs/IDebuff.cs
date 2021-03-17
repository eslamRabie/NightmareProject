namespace Levels.Scripts.Elements
{
    public interface IDebuff<TEffector>
    {
        public abstract void Effect(TEffector effector);
    }
}