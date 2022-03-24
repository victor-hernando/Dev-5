using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command
{
    public AttackCommand() : base()
    {
        _myType = FightCommandTypes.Attack;
        PossibleTargets = TargetTypes.Enemy;
    }
    public override void Excecute()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).TakeDamage(((Fighter)_actor).Attack);
        }
    }

    public override void Undo()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).RestoreDamage(((Fighter)_actor).Attack);
        }
    }
}
public class ReviveCommand : Command
{
    public ReviveCommand() : base()
    {
        _myType = FightCommandTypes.Revive;
        PossibleTargets = TargetTypes.Dead;
    }
    public override void Excecute()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).Revive(true);
        }
    }

    public override void Undo()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).Revive(true);
        }
    }
}
public class BoostAttackCommand : Command
{
    public BoostAttackCommand() : base()
    {
        _myType = FightCommandTypes.BoostAttack;

        PossibleTargets = TargetTypes.Self;
    }
    public override void Excecute()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).AddAttackPermanent(1);
        }
    }

    public override void Undo()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).AddAttackPermanent(-1);
        }
    }
}
public class BoostDefenseCommand : Command
{
    public BoostDefenseCommand() : base()
    {
        _myType = FightCommandTypes.BoostDefense;
        PossibleTargets = TargetTypes.Self;
    }
    public override void Excecute()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).AddDefensePermanent(1);
        }
    }

    public override void Undo()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).AddDefensePermanent(-1);
        }
    }
}
public class ShieldCommand : Command
{
    public ShieldCommand() : base()
    {
        _myType = FightCommandTypes.Shield;
        PossibleTargets = TargetTypes.FriendNotSelf;
    }
    public override void Excecute()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).AddDefense(5);
        }
    }

    public override void Undo()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).AddDefense(-5);
        }
    }
}
public class HealCommand : Command
{
    public HealCommand() : base()
    {
        _myType = FightCommandTypes.Heal;
        PossibleTargets = TargetTypes.Friend;
    }
    public override void Excecute()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).Heal(3);
        }
    }

    public override void Undo()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).Heal(-3);
        }
    }
}

public class UpgradeCommand : Command
{
    public UpgradeCommand() : base()
    {
        _myType = FightCommandTypes.Upgrade;
        PossibleTargets = TargetTypes.Self;
    }
    public override void Excecute()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).Heal(3);
        }
    }

    public override void Undo()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).Heal(-3);
        }
    }
}
