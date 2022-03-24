using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : ICommand
{
    public Entity _entity;
    public Entity _actor;
    protected FightCommandTypes _myType;
    public TargetTypes PossibleTargets;

    public FightCommandTypes myType => _myType;

    public Command() 
    {
    }
    internal void Init(Entity target, Entity actor)
    {
        _entity = target;
        _actor = actor;
    }
    public abstract void Excecute();
    public abstract void Undo();
}
