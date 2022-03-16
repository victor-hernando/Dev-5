using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField] private List<Entity> Entities;
    private int _currentIndex;

    public Entity ActiveEntity => Entities[_currentIndex];

    public Entity OtherEntity => Entities[++_currentIndex % Entities.Count];

    public List<Entity> Enemies => Entities.Where(x => x.Team != ActiveEntity.Team).ToList();
    public Entity Friend => Entities.Where(x => x.Team == ActiveEntity.Team && x != ActiveEntity).ToList()[0];




    public void SetNextEntity()
    {
        _currentIndex++;
        _currentIndex = _currentIndex % Entities.Count;
    }

    public void SetPreviousEntity()
    {
        _currentIndex--;
        if (_currentIndex < 0)
            _currentIndex = Entities.Count - 1;
    }
}
