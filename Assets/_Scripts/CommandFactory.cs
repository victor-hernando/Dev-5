using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Linq;

public class CommandFactory
{
    private Dictionary<FightCommandTypes, Type> _commandByName;
    public CommandFactory()
    {
        var commandTypes = Assembly.GetAssembly(typeof(ICommand)).GetTypes().Where(x => !x.IsInterface && typeof(ICommand).IsAssignableFrom(x) && !x.IsAbstract);
        _commandByName = new Dictionary<FightCommandTypes, Type>();
        foreach (var commadType in commandTypes)
        {
            var tempCommand = Activator.CreateInstance(commadType);
            _commandByName.Add(((ICommand)tempCommand).myType, commadType);
        }
    }

    internal FightCommandTypes[] GetAllNames()
    {
        return _commandByName.Keys.ToArray();
    }

    public ICommand GetCommand(FightCommandTypes commandType)
    {
        if (_commandByName.ContainsKey(commandType))
        {
            return Activator.CreateInstance(_commandByName[commandType]) as ICommand;
        }
        Debug.Log("No Existe");
        return null;
    }
}

