using Godot;
using System;

public partial class BackgroundMusic : AudioStreamPlayer
{
    const string EXPLODE_SOUND = "res://Assets/explode.wav";
    const string BACKGROUND_SOUND = "res://Assets/bgm_action_5.mp3";

    public void PlayExplodeSound()
    {
        Stop();
        Stream = ResourceLoader.Load<AudioStream>(EXPLODE_SOUND);
        Play();
    }

    public void PlayeBackgroundSound()
    {
        Stop();
        Stream = ResourceLoader.Load<AudioStream>(BACKGROUND_SOUND);
        Play();
    }
}