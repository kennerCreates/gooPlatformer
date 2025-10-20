using Godot;
using gooPlatformer.Configuration;

namespace gooPlatformer.Scripts.Animation.FollowJoint;

public class FollowJointUtils
{
    public static Vector2 LocationForTick(FollowJointOptions options, float dt) => 
        options.CurrentPosition.Lerp(options.TargetPosition, options.FollowSpeed * dt);
    public static Vector2 MovementDirectionVector(FollowJointOptions options) => 
        options.TargetPosition - options.CurrentPosition;
    public static float DistanceToTarget(FollowJointOptions options) => 
        options.CurrentPosition.DistanceTo(options.TargetPosition);
}