using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    public string Name;

    public virtual void PlayerChooseTarget(BattleSystem battleSystem)
    {

    }

    public virtual void EnemyChooseTarget(BattleSystem battleSystem)
    {

    }

    public virtual void StartingExecuteSkill(BattleSystem battleSystem)
    {

    }
}
