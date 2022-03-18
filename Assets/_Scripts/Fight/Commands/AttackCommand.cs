using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command
{
    
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
