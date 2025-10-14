using Godot;

namespace gooPlatformer.Scripts.Animation;

[GlobalClass]
public partial class Joint : Node2D
{
    public Node2D ParentNode { get; init; }
}