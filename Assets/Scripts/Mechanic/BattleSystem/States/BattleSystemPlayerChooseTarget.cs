using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using System.Threading.Tasks;

public class BattleSystemPlayerChooseTarget : BattleSystemBaseState
{
    private Skill chosenSkill;
    private Camera camera;

    public override void StartingState(BattleSystem battleSystem)   
    {
        Debug.Log("Start Player Choose Target State");
    }

    public void SetSkill(Skill skill)
    {
        chosenSkill = skill;
    }

    public override void ProceedingState(BattleSystem battleSystem)
    {
        chosenSkill.PlayerChooseTarget(battleSystem);
    }
}
