using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public int Points => _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName}: {_description}";
    }
}