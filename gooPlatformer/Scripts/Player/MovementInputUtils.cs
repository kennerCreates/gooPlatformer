using gooPlatformer.Configuration;
using Vector2 = Godot.Vector2;

namespace gooPlatformer.Scripts.Player;

public static class MovementInputUtils
{
    public static bool IssNonZeroInput(MovementInputOptions options) =>
        NormalizedInputVector(options) != Vector2.Zero;
    public static Vector2 NormalizedInputVector(MovementInputOptions options) =>
        new Vector2(XInput(options), YInput(options)).Normalized();
    public static float XInput(MovementInputOptions options) => options.RightInput - options.LeftInput;
    public static float YInput(MovementInputOptions options) => options.DownInput - options.UpInput;
}
