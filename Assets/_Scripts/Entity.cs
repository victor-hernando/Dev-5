using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, ISelectable
{
    public EntityManager entityManager;
    public int entityIdx;

    protected Color normalColor;

    public Team Team;

    public string nom;

    public void ClickedBad()
    {
        
    }

    public virtual void SetEntityManager(EntityManager manager, int idx)
    {
    }

    public void ClickedGood()
    {
        GetComponent<SpriteRenderer>().color = normalColor;
    }

    public void HighlightBad()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void HighlightGood()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void UnSelect()
    {
        GetComponent<SpriteRenderer>().color = normalColor;
    }

    public virtual void Die()
    {
        normalColor = Color.gray;
        GetComponent<SpriteRenderer>().color = normalColor;
    }

    public void Revive()
    {
        normalColor = Color.white;
        GetComponent<SpriteRenderer>().color = normalColor;
    }

    /*public void Upgrade()
    {
        GetComponent<SpriteRenderer>().sprite = GetComponentInChildren<SpriteRenderer>().sprite;
    }*/
}

public enum Team
{
    TeamA,
    TeamB,
}
