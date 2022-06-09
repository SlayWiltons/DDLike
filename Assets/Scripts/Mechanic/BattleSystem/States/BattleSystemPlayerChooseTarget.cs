using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BattleSystemPlayerChooseTarget : BattleSystemBaseState
{
    private Skill chosenSkill;

    public override void StartingState(BattleSystem battleSystem)
    {
        Debug.Log(chosenSkill);
    }

    public void SetSkill(Skill skill)
    {
        chosenSkill = skill;
    }

    public override void ProceedingState(BattleSystem battleSystem)
    {
        
    }
}
