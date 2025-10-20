using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Godot;

namespace gooPlatformer.Scripts.Animation;

[Tool]
public partial class CreatureCreator : Node2D
{
    [Export] private int NumberOfLimbs { get; set; }
    [Export] private int NumberOfSegments { get; set; }
    [Export] private Vector2 SegmentTargetSize { get; set; }

    private readonly List<Node2D> _segments = [];

    public override void _Ready()
    {

    }

    public override void _Process(double delta)
    {
        if (Engine.IsEditorHint())
        {
            if (Input.IsActionJustPressed("ui_focus_next"))
            {
                if (_segments.Count != NumberOfSegments)
                {
                    foreach (var segment in _segments)
                    {
                        segment.QueueFree();
                    }
                }

                for (var i = 0; i < NumberOfSegments; i++)
                {
                    var node = new Node2D();

                    _segments.Add(node);

                    AddChild(node);
                    node.Name = $"Segment {i}";
                    node.Owner = GetTree().EditedSceneRoot;
                }
            }
        }
    }
}

