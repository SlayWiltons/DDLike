using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackSkill", menuName = "Skill/Attack skill")]
public class AttackSkill : Skill
{
    [Min(0)] public int minDamage;
    [Min(0)] public int maxDamage;
    public DamageType damageType;

    public int Damage()
    {
        var rand = Random.Range(minDamage, maxDamage);
        return rand;
    }
}
