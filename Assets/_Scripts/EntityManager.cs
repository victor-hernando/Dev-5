using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField] private List<Entity> aliveEntities;
    [SerializeField] private List<Entity> allEntities;
    private int _currentIndex;
    public int EntitiesNum => aliveEntities.Count;
    public Entity ActiveEntity => aliveEntities[_currentIndex];

    public Entity OtherEntity => aliveEntities[++_currentIndex % aliveEntities.Count];

    public Entity[] Enemies => aliveEntities.Where(x => x.Team != ActiveEntity.Team).ToArray();
    public Entity[] Friends => aliveEntities.Where(x => x.Team == ActiveEntity.Team).ToArray();
    public Entity[] FriendsNotSelf => aliveEntities.Where(x => x.Team == ActiveEntity.Team && x != ActiveEntity).ToArray();
    public Entity[] Deads => allEntities.Where(x => !aliveEntities.Contains(x)).ToArray();

    private void Start()
    {
        aliveEntities = allEntities;
        for(int idx = 0; idx < allEntities.Count; idx++)
        {
            allEntities[idx].SetEntityManager();
        }
    }

    public void SetNextEntity()
    {
        _currentIndex++;
        CheckRound();
        _currentIndex = _currentIndex % aliveEntities.Count;
    }

    private void CheckRound()
    {
        if (_currentIndex >= aliveEntities.Count)
        {
            //Executem totes els commandos pendents abans de resetejar els stats temporals
            Invoker.ExecuteAll();
            foreach(Entity ent in aliveEntities)
            {
                (ent as Fighter).ResetFighter();
            }
        }
    }

    public void SetPreviousEntity()
    {
        _currentIndex--;
        if (_currentIndex < 0)
            _currentIndex = aliveEntities.Count - 1;
    }
    public void RemoveEntity(Entity entity)
    {
        aliveEntities.Remove(entity);
    }

    public void AddEntity(Entity entity, int idx)
    {
        aliveEntities.Insert(idx, entity);
    }
}
