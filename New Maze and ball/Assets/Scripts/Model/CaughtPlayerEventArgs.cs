using UnityEngine;


namespace NewMazeAndBall
{
    internal sealed class CaughtPlayerEventArgs
    {
        internal Color _color { get; }
        internal CaughtPlayerEventArgs(Color Color)
        {
            _color = Color;
        }
    }
}
