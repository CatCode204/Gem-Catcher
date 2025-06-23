using Godot;
using System;

public partial class Game : Node2D
{
    const string GEM_SCENE = "res://Scenes/Gem/gem.tscn";
    const string TIMER_NODE = "Timer";
    const string PADDLE_NODE = "Paddle";
    const string LABEL = "Label";
    const float MARGIN = 70.0f;
    [Signal]
    private delegate void OnGameLoseEventHandler();
    private PackedScene _gemScene;
    private Timer _timer;
    private Paddle _paddle;
    private Label _label;
    private int _score = 0;
    public override void _Ready()
    {
        _gemScene = ResourceLoader.Load<PackedScene>(GEM_SCENE);
        _timer = GetNode<Timer>(TIMER_NODE);
        _paddle = GetNode<Paddle>(PADDLE_NODE);
        _label = GetNode<Label>(LABEL);
        OnGameLose += GameLose;
    }
    private void UpdateScore(Area2D area)
    {
        ++_score;
        _label.Text = String.Format("{0:D3}",_score); 
    }
    private void SpawnGem()
    {
        Gem gem = _gemScene.Instantiate<Gem>();
        float initPosX = (float)GD.RandRange(GetViewportRect().Position.X + MARGIN, GetViewportRect().End.X - MARGIN);
        gem.Position = new Vector2(initPosX, -50.0f);
        gem.OnGemOffScreen += () => EmitSignal(SignalName.OnGameLose);
        AddChild(gem);
    }
    private void GameLose()
    {
        foreach (Node child in GetChildren())
            if (child is Gem)
                child.SetProcess(false);
        _timer.Stop();
        _paddle.SetProcess(false);
    }
}