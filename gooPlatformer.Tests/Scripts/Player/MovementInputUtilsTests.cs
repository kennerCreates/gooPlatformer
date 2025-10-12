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
}