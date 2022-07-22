using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public string nameCharacter;
    public int hp;
    public int currentHP;

    public int minDamage;   //Пока парметры мин/макс дамага, далее можно использовать параметры типа Сила/Интеллект/Ловкость и т.д. , а в самих скиллах высчитывать порог дамага
    public int maxDamage;

    public List<Skill> skills;
    public bool isEnemy;
    public bool isReady;
    public bool isDead;
}
