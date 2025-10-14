using Godot;
using gooPlatformer.Configuration;
using gooPlatformer.GodotInterface.Models;

namespace gooPlatformer.Scripts.Animation;

public class ProceduralAnimUtils
{
    public static RigidBody CreateBody(ProceduralAnimOptions options) => new()
    {

    };
    public static RigidBody CreateSegment(ProceduralAnimOptions options) => new()
    {
        CollisionCircle = CreateCollisionCircle(options),
        Sprite = CreateSprite(options)
    };
    
    
    public static Sprite CreateSprite(ProceduralAnimOptions options) => new()
    {
        TextureFilepath = options.SpriteFilepath
    };

    public static CollisionCircle CreateCollisionCircle(ProceduralAnimOptions options) => new()
    {
        Circle = CreateCircle(options)
    };

    public static Circle CreateCircle(ProceduralAnimOptions options) => new()
    {
        Radius = options.CollisionRadius
    };
}