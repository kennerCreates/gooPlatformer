using Godot;
using gooPlatformer.Configuration;

namespace gooPlatformer.Scripts.Animation.FollowJoint;

[GlobalClass]
public partial class FollowJointScript : Area2D
{
    [Export] public Node2D TargetNode;
    [Export] public float FollowSpeed;
    
    private FollowJointOptions InputOptions => new()
    {
        TargetPosition = TargetNode.GetGlobalPosition(),
        CurrentPosition = GetGlobalPosition(),
        FollowSpeed = FollowSpeed
    };

    private readonly FollowJointOptions _originalInputOptions;

    public FollowJointScript()
    {
        _originalInputOptions = new()
        {
            LocalOffset = GetPosition()
        };
    }

    public override void _Process(double delta)
    {
        var dt = (float)delta;
        
    }
    private void OnTick(float dt)
    {
        SetPosition(FollowJointUtils.LocationForTick(InputOptions, dt));
        //SetRotation();
    }
}
