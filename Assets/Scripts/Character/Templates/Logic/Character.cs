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

    public int minDamage;   //���� �������� ���/���� ������, ����� ����� ������������ ��������� ���� ����/���������/�������� � �.�. , � � ����� ������� ����������� ����� ������
    public int maxDamage;

    public List<Skill> skills;
    public bool isEnemy;
    public bool isReady;
    public bool isDead;
}
