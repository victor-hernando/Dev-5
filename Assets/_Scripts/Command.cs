﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : ICommand
{
    protected Entity _entity;
    protected FightCommandTypes _myType;
    public TargetTypes PossibleTargets;

    public FightCommandTypes myType => _myType;

    protected Command(Entity entity)
    {
        _entity = entity;
    }

    public abstract void Excecute();
    public abstract void Undo();
}
