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
    public AttackCommand(Entity entity) : base(entity)
    {
        _myType = FightCommandTypes.Attack;
    }
    public override void Excecute()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).TakeDamage(10);
        }
    }

    public override void Undo()
    {
        if (_entity is Fighter)
        {
            (_entity as Fighter).Heal(5);
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
    public BoostAttackCommand(Entity entity) : base(entity)
    {
        _myType = FightCommandTypes.BoostAttack;
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
    public BoostDefenseCommand(Entity entity) : base(entity)
    {
        _myType = FightCommandTypes.BoostDefense;
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
    public ShieldCommand(Entity entity) : base(entity)
    {
        _myType = FightCommandTypes.Shield;
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
    public HealCommand(Entity entity) : base(entity)
    {
        _myType = FightCommandTypes.Heal;
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

    public UpgradeCommand(Entity entity) : base(entity)
    {
        _myType = FightCommandTypes.Upgrade;
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
