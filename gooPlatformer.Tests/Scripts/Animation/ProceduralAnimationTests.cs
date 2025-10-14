using Godot;
using gooPlatformer.Configuration;
using gooPlatformer.GodotInterface.Models;
using gooPlatformer.Scripts.Animation;

namespace gooPlatformer.Tests.Scripts.Animation;

public class ProceduralAnimationTests
{
    [Fact]
    public void CreateCircle()
    {
        var options = new ProceduralAnimOptions
        {
            CollisionRadius = 24
        };
        var expected = new Circle
        {
            Radius = 24
        };
        
        var actual = ProceduralAnimUtils.CreateCircle(options);
        
        Assert.Equivalent(expected, actual);
    }

    [Fact]
    public void CreateCollisionCircle()
    {
        var options = new ProceduralAnimOptions
        {
            CollisionRadius = 24
        };
        var circle = new Circle
        {
            Radius = 24
        };
        var expected = new CollisionCircle
        {
            Circle = circle
        };
        var actual = ProceduralAnimUtils.CreateCollisionCircle(options);
        
        Assert.Equivalent(expected, actual);

    }

    [Fact]
    public void CreateSprite()
    {
        var options = new ProceduralAnimOptions()
        {
            SpriteFilepath = "res://Assets/Sprites/circle.png",
        };
        var expected = new Sprite
        {
            TextureFilepath = "res://Assets/Sprites/circle.png",
        };
        var actual = ProceduralAnimUtils.CreateSprite(options);
        
        Assert.Equivalent(expected, actual);
        
    }

    [Fact]
    public void CreateSegment()
    {
        var options = new ProceduralAnimOptions()
        {
            LimbCount = 1,
            LimbSegmentCount = 4,
            SegmentTargetSize = 24,
            SpriteFilepath = "res://Assets/Sprites/circle.png",
            CollisionRadius = 12
        };
        var sprite = new Sprite
        {
            TextureFilepath = "res://Assets/Sprites/circle.png"
        };
        var circle = new Circle
        {
            Radius = 12
        };
        var collisionCircle = new CollisionCircle
        {
            Circle = circle
        };
        var expected = new RigidBody()
        {
            CollisionCircle = collisionCircle,
            Sprite = sprite
        };
        
        var actual = ProceduralAnimUtils.CreateSegment(options);
        
        Assert.Equivalent(expected, actual);
    }
}
