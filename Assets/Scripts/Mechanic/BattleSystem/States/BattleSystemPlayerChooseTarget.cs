using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BattleSystemPlayerChooseTarget : BattleSystemBaseState
{
    private Skill chosenSkill;
    private Camera camera;

    public override void StartingState(BattleSystem battleSystem)
    {
        Debug.Log(chosenSkill);
        camera = Camera.main;
    }

    public void SetSkill(Skill skill)
    {
        chosenSkill = skill;
    }

    public override void ProceedingState(BattleSystem battleSystem)
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            
        }
    }
}
