using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand 
{
    FightCommandTypes myType { get; }

    void Excecute();
    void Undo();
}
