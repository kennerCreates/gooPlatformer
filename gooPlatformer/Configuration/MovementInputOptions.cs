using Godot;

namespace gooPlatformer.Configuration;

public class MovementInputOptions
{
    public Vector2 MouseInput { get; init; }
    public Vector2 PlayerLocation { get; init; }
    public float LeftInput { get; init; }
    public float RightInput { get; init; }
    public float DownInput { get; init; }
    public float UpInput { get; init; }
    public float Speed { get; init; }
    public float Acceleration { get; init; }
}