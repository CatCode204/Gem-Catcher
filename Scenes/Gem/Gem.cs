using Godot;
using System;

public partial class Gem : Area2D
{
    [Signal]
    public delegate void OnGemOffScreenEventHandler();
    [Export] private float _speed;

    public override void _Process(double delta)
    {
        Position += Vector2.Down * _speed * (float)delta;
        Rect2 rect = GetViewportRect();

        if (Position.Y >= rect.End.Y)
        {
            EmitSignal(SignalName.OnGemOffScreen);
        }
    }

    public void DeleteGem(Area2D area)
    {
        QueueFree();
    }
}