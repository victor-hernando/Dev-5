using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EntityManager EntityManager;
    public ActionButtonController ActionButtonController;
    public ChooseTarget TargetChooser;
    public Invoker Invoker;
    public StatsUI Stats;
    public CommandFactory _factory;
    int turn;

    FightCommandTypes currentType;

    // Start is called before the first frame update
    void Start()
    {
        _factory = new CommandFactory();
        StartBattle();
        turn = 0;
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
           // Undo();
    }

    void StartBattle()
    {
        //1
        ActionButtonController.Show();
    }

    public void DoAction(FightCommandTypes commandType)
    {
        //cridar factory /crear commando
        //2
        currentType = commandType;
        ChooseTarget((_factory.GetCommand(currentType))as Command);
    }
    
    private void ChooseTarget(Command _currentCommand)
    {
        TargetTypes targetTypes = _currentCommand.PossibleTargets;

        Entity[] possibleTargets;

        switch (targetTypes)
        {
            case TargetTypes.Enemy:
                possibleTargets = EntityManager.Enemies;
                break;
            case TargetTypes.Friend:
                possibleTargets = EntityManager.Friends;
                break;
            case TargetTypes.FriendNotSelf:
                possibleTargets = EntityManager.FriendsNotSelf;
                break;
            case TargetTypes.Self:
                possibleTargets = new Entity[1];
                possibleTargets[0] = EntityManager.ActiveEntity;
                break;

            default:
                possibleTargets = EntityManager.Enemies;
                break;
        }
        ActionButtonController.ChooseTarget(EntityManager.ActiveEntity);
        TargetChooser.StartChoose(possibleTargets);
    }
    private void DoAction(Entity actor, Entity target, FightCommandTypes type)
    {
        var commando = _factory.GetCommand(currentType);
        (commando as Command)._entity = target;
        Invoker.AddCommand(commando);
    }

    private void OnUndo()
    {
        if (turn > 0)
        {
            //Undo limitat fins al principi de la ronda
            EntityManager.SetPreviousEntity();
            Invoker.Undo();
            ActionButtonController.DeleteButtons();
            turn -= 2;
            NextTurn();
            print(turn);
        }
    }

    public void NextTurn()
    {
        turn++;
        turn %= EntityManager.EntitiesNum;
        StartBattle();
    }

    internal void TargetChosen(ISelectable entity)
    {
        if(!(entity is Entity))
        {
            Debug.LogError("Selected is not entity");
            return;
        }
        DoAction(EntityManager.ActiveEntity, entity as Entity, currentType);
        EntityManager.SetNextEntity();
        NextTurn();
    }
}
