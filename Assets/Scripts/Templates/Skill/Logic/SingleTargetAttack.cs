using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SingleTargetAttackSkill", menuName = "Skill/Attack skill/Single target")]
public class SingleTargetAttack : AttackSkill
{
    private Hero chosenTarget;

    public override void PlayerChooseTarget(BattleSystem battleSystem)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (!hit)
            {
                return;
            }
            if (hit.transform.gameObject.GetComponent<Hero>().IsEnemy())
            {
                chosenTarget = hit.transform.gameObject.GetComponent<Hero>();
                StartingExecuteSkill(battleSystem);
            }
        }
    }

    public override void EnemyChooseTarget(BattleSystem battleSystem)
    {
        int randTarget = Random.Range(0, battleSystem.activeCharacter.enemiesList.Count);
        chosenTarget = battleSystem.activeCharacter.enemiesList[randTarget];
        StartingExecuteSkill(battleSystem);
    }

    public override void StartingExecuteSkill(BattleSystem battleSystem)
    {
        chosenTarget.TakeDamage(Damage());
        battleSystem.activeCharacter.SetAsNotReady();
        battleSystem.SetState(battleSystem.CalculatingResultsState);
    }
}
