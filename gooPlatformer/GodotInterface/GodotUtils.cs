using Godot;
using gooPlatformer.GodotInterface.Models;
using gooPlatformer.GodotInterface.Models.EngineNodes;
using Node = Godot.Node;
using Node2D = Godot.Node2D;

namespace gooPlatformer.GodotInterface;

public static class GodotUtils
{
    public static CircleShape2D ToGodotCircleShape2D(this Circle circle) => new()
    {
        Radius = circle.Radius
    };
    
    public static CollisionShape2D ToGodotCollisionShape2D(this CollisionCircle collisionCircle) => new()
    {
        Shape = collisionCircle.Circle.ToGodotCircleShape2D()
    };
    
    public static Sprite2D ToGodotSprite2D(this Sprite sprite) => new()
    {
        Texture = GD.Load<Texture2D>(sprite.TextureFilepath),
    };

    public static RigidBody2D ToGodotRigidBody2D(this RigidBody rigidBody)
    {
        var godotRigidBody = new RigidBody2D();
        
        godotRigidBody.AddChild(ToGodotSprite2D(rigidBody.Sprite));
        godotRigidBody.AddChild(ToGodotCollisionShape2D(rigidBody.CollisionCircle));
        
        return godotRigidBody;
    }

    public static Node2D ToGodotNode2D(this Node node) => new();
}