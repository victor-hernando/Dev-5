using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FightCommandTypes
{
    Attack,
    BoostAttack,
    BoostDefense,
    Heal,
    Shield,
    Upgrade,
    Revive,
}

public enum TargetTypes
{
    Enemy,
    Friend,
    Self,
    FriendNotSelf,
    Dead,
}