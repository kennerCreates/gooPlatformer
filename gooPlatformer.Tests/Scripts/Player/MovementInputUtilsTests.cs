using Godot;
using gooPlatformer.Configuration;
using gooPlatformer.Scripts.Player;

namespace gooPlatformer.Tests.Scripts.Player;

public class MovementInputUtilsTests
{
    [Theory]
    [InlineData(0.2f, 0.5f, -0.3f)]
    [InlineData(0.0f, 0.0f, 0.00f)]
    public void XInput(float rightInput, float leftInput, float expected)
    {
        var options = new MovementInputOptions
        {
            RightInput = rightInput,
            LeftInput = leftInput,
            DownInput = 0.2f,
            UpInput = 0.1f
        };
        
        var actual = MovementInputUtils.XInput(options);
        
        Assert.Equal(expected, actual, 4);
    }
    
    [Theory]
    [InlineData(0.2f, 0.5f, -0.3f)]
    [InlineData(0.0f, 0.0f, 0.00f)]
    public void YInput(float downInput, float upInput, float expected)
    {
        var options = new MovementInputOptions
        {
            RightInput = 0.5f,
            LeftInput = 0.2f,
            DownInput = downInput,
            UpInput = upInput
        };
        
        var actual = MovementInputUtils.YInput(options);
        
        Assert.Equal(expected, actual, 4);
    }

    [Fact]
    public void NormalizedInputVector()
    {
        var options = new MovementInputOptions
        {
            RightInput = 0.5f,
            LeftInput = 0.2f,
            DownInput = 0.2f,
            UpInput = 0.1f
        };
        var inputVector = new Vector2(0.3f, 0.1f);
        var expected = inputVector.Normalized();
        
        var actual = MovementInputUtils.NormalizedInputVector(options);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNonZeroInput_MultiInput_True()
    {
        var options = new MovementInputOptions
        {
            RightInput = 0.5f,
            LeftInput = 0.2f,
            DownInput = 0.2f,
            UpInput = 0.1f
        };
        
        var actual = MovementInputUtils.IsNonZeroInput(options);
        
        Assert.True(actual);
    }
    
    [Fact]
    public void IsNonZeroInput_SingleInput_True()
    {
        var options = new MovementInputOptions
        {
            RightInput = 0.5f,
            LeftInput = 0f,
            DownInput = 0f,
            UpInput = 0f
        };
        
        var actual = MovementInputUtils.IsNonZeroInput(options);
        
        Assert.True(actual);
    }
    
    [Fact]
    public void IsNonZeroInput_False()
    {
        var options = new MovementInputOptions
        {
            RightInput = 0f,
            LeftInput = 0f,
            DownInput = 0f,
            UpInput = 0f
        };
        
        var actual = MovementInputUtils.IsNonZeroInput(options);
        
        Assert.False(actual);
    }

    [Fact]
    public void TargetVelocity()
    {
        var options = new MovementInputOptions
        {
            RightInput = 0.5f,
            LeftInput = 0.2f,
            DownInput = 0.2f,
            UpInput = 0.1f,
            Speed = 300f
        };
        var inputVector = new Vector2(0.3f, 0.1f);
        var expected = inputVector.Normalized() * 300f;
        
        var actual = MovementInputUtils.TargetVelocity(options);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void VelocityForTick()
    {
        var options = new MovementInputOptions
        {
            RightInput = 1.3f,
            LeftInput = 0f,
            DownInput = 0f,
            UpInput = 0f,
            Speed = 300f,
            Acceleration = 1000f
        };
        var velocity = new Vector2(100f, 100f);
        var expected = new Vector2(189.44272f, 55.27864f);
        
        var actual = MovementInputUtils.VelocityForTick(velocity, .1f, options);
        
        Assert.Equal(expected, actual);
    }
}