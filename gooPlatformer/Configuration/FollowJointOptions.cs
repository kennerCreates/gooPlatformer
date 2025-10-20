using Godot;

namespace gooPlatformer.Configuration;

public class FollowJointOptions
{
    public Vector2 TargetPosition { get; init; }
    public Vector2 CurrentPosition { get; init; }
    public float FollowSpeed { get; init; }
    public Vector2 LocalOffset { get; init; }
}