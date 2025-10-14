using gooPlatformer.Configuration;
using Vector2 = Godot.Vector2;

namespace gooPlatformer.Scripts.Player;

public static class MovementInputUtils
{
    public static Vector2 VelocityForTick(Vector2 velocity, float dt, MovementInputOptions options) =>
        velocity.MoveToward(TargetVelocity(options), options.Acceleration * dt);
    public static Vector2 TargetVelocity(MovementInputOptions options) => NormalizedInputVector(options) * options.Speed;
    public static bool IsNonZeroInput(MovementInputOptions options) =>
        NormalizedInputVector(options) != Vector2.Zero;
    public static Vector2 NormalizedInputVector(MovementInputOptions options) =>
        MovementDirectionVector(options).Normalized();
    public static Vector2 MovementDirectionVector(MovementInputOptions options) => options.MouseInput - options.PlayerLocation;
}
