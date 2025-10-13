using Godot;
using gooPlatformer.Configuration;
using gooPlatformer.Scripts.Player;

namespace gooPlatformer.Tests.Scripts.Player;

public class MovementInputUtilsTests
{
    [Fact]
    public void MovementDirectionVector()
    {
        var options = new MovementInputOptions
        {
            MouseInput = new Vector2(37f, 100f),
            PlayerLocation = new Vector2(-22f, 23f)
        };
        var expected = new Vector2(59f, 77f);
        
        var actual = MovementInputUtils.MovementDirectionVector(options);
        
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void NormalizedInputVector()
    {
        var options = new MovementInputOptions
        {
            MouseInput = new Vector2(-50f, 100f),
            PlayerLocation = new Vector2(1f, 4.5f)
        };
        var inputVector = options.MouseInput - options.PlayerLocation;
        var expected = inputVector.Normalized();
        
        var actual = MovementInputUtils.NormalizedInputVector(options);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNonZeroInput_True()
    {
        var options = new MovementInputOptions
        {
            MouseInput = new Vector2(37f, 100f),
            PlayerLocation = new Vector2(-22f, 23f)
        };
        
        var actual = MovementInputUtils.IsNonZeroInput(options);
        
        Assert.True(actual);
    }
    
    
    [Fact]
    public void IsNonZeroInput_False()
    {
        var options = new MovementInputOptions
        {
            MouseInput = new Vector2(37f, 23f),
            PlayerLocation = new Vector2(37f, 23f)
        };
        
        var actual = MovementInputUtils.IsNonZeroInput(options);
        
        Assert.False(actual);
    }

    [Fact]
    public void TargetVelocity()
    {
        var options = new MovementInputOptions
        {
            MouseInput = new Vector2(37f, 100f),
            PlayerLocation = new Vector2(-22f, 23f),
            Speed = 300f
        };
        var inputVector = options.MouseInput - options.PlayerLocation;
        var expected = inputVector.Normalized() * 300f;
        
        var actual = MovementInputUtils.TargetVelocity(options);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void VelocityForTick()
    {
        var options = new MovementInputOptions
        {
            MouseInput = new Vector2(37f, 100f),
            PlayerLocation = new Vector2(-22f, 23f),
            Speed = 300f,
            Acceleration = 1000f
        };
        var inputVector = options.MouseInput - options.PlayerLocation;
        var velocity = inputVector.Normalized() * options.Speed;
        var expected = new Vector2(182.46452f, 238.13167f);
        
        var actual = MovementInputUtils.VelocityForTick(velocity, .1f, options);
        
        Assert.Equal(expected, actual);
    }
}