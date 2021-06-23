namespace NewMazeAndBall
{
    internal interface IInteractable : IAction, IInitialization
    {
        bool IsInteractable { get; }
    }
}
