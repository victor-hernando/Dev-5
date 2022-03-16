using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField] private List<Entity> Entities;
    private int _currentIndex;

    public Entity ActiveEntity => Entities[_currentIndex];

    public Entity OtherEntity => Entities[++_currentIndex % Entities.Count];

   

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
