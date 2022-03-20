using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command
{
    public AttackCommand() : base()
    { 
    }
    public AttackCommand(Entity entity) : base(entity)
    {
        _myType = FightCommandTypes.Attack;
    }
    public override void Excecute()
    {
        
    }

    public override void Undo()
    {
        
    }
}
public class BoostAttackCommand : Command
{
    public BoostAttackCommand() : base()
    {
    }
    public BoostAttackCommand(Entity entity) : base(entity)
    {
        _myType = FightCommandTypes.BoostAttack;
    }
    public override void Excecute()
    {

    }

    public override void Undo()
    {

    }
}
public class BoostDefenseCommand : Command
{
    public BoostDefenseCommand() : base()
    {
    }
    public BoostDefenseCommand(Entity entity) : base(entity)
    {
        _myType = FightCommandTypes.BoostDefense;
    }
    public override void Excecute()
    {

    }

    public override void Undo()
    {

    }
}
public class ShieldCommand : Command
{
    public ShieldCommand() : base()
    {
    }
    public ShieldCommand(Entity entity) : base(entity)
    {
        _myType = FightCommandTypes.Shield;
    }
    public override void Excecute()
    {

    }

    public override void Undo()
    {

    }
}
public class HealCommand : Command
{
    public HealCommand() : base()
    {
    }
    public HealCommand(Entity entity) : base(entity)
    {
        _myType = FightCommandTypes.Heal;
    }
    public override void Excecute()
    {

    }

    public override void Undo()
    {

    }
}
