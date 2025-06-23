using Godot;
using System;

public partial class Paddle : Area2D
{
    [Export] private float _moveSpeed;
    public override void _Process(double delta)
    {
        float horizontalMovement = Input.GetAxis("move_left", "move_right");
        Position += Vector2.Right * horizontalMovement * _moveSpeed * (float)delta;

        float clampedPositionX = Mathf.Clamp(Position.X, GetViewportRect().Position.X, GetViewportRect().End.X);
        Position = new Vector2(clampedPositionX, Position.Y);
    }
}