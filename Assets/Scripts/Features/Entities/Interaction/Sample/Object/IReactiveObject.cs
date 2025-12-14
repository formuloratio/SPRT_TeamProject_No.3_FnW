namespace Features.Entities.Interaction.Sample
{
    public interface IReactiveObject
    {
        void Activate();
        void Deactivate();
        ReactiveType ReactiveType { get; }
        ActionType ActionType { get; }
    }
    public enum ReactiveType
    {
        Moving, Vanishing, Passing
    }

    public enum ActionType
    {
        Maintain, Once
    }
}