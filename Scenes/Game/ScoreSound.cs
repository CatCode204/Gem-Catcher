using Godot;
using System;

public partial class ScoreSound : AudioStreamPlayer2D
{
    public void PlaySound(Area2D area)
    {
        if (!Playing)
        {
            Position = area.Position;
            Play();
        }
    }
}