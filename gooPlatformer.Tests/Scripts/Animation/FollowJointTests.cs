using Godot;
using gooPlatformer.Configuration;
using gooPlatformer.Scripts.Animation.FollowJoint;

namespace gooPlatformer.Tests.Scripts.Animation;

public class FollowJointTests
{
    [Fact]
    public void DistanceToTarget()
    {
        var options = new FollowJointOptions()
        {
            CurrentPosition = new Vector2(25f, 30f),
            TargetPosition = new Vector2(350f,50f)
        };
        var expected = options.CurrentPosition.DistanceTo(options.TargetPosition);
        
        var actual = FollowJointUtils.DistanceToTarget(options);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MovementDirectionVector()
    {
        var options = new FollowJointOptions()
        {
            CurrentPosition = new Vector2(25f, 0f),
            TargetPosition = new Vector2(350f, 00f)
        };
       var expected = options.TargetPosition - options.CurrentPosition;
       
       var actual = FollowJointUtils.MovementDirectionVector(options);
       
       Assert.Equal(expected, actual);
       
    }

    [Fact]
    public void LocationForTick()
    {
        var options = new FollowJointOptions()
        {
            CurrentPosition = new Vector2(25f, 0f),
            TargetPosition = new Vector2(350f, 30f),
            FollowSpeed = 50f
        };
        var expected = options.CurrentPosition.Lerp(options.TargetPosition, .1f * options.FollowSpeed);
        
        var actual = FollowJointUtils.LocationForTick(options, .1f);
        
        Assert.Equal(expected, actual);
    }
}