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
        
        
    }

    public void SetSkill(Skill skill)
    {
        chosenSkill = skill;
    }

    public override void ProceedingState(BattleSystem battleSystem) //Перенести выбор цели в сам скилл, а в состоянии вызывать первую его функцию (напр. ChooseTarget)
    {
        chosenSkill.StartingExecuteSkill(battleSystem);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);//, Mathf.Infinity);
            if (hit)
            {
                Debug.Log(hit.collider.gameObject.name);
            }

        }
    }
}
