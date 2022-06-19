using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Hero : MonoBehaviour, IDamageable<int>, IKillable
{
    [SerializeField] private Character character;
    private string nameCharacter;
    private int hp;
    private bool isEnemy;
    private bool isReady;
    private bool isDead;
    public List<Skill> skillsList;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = character.sprite;
        nameCharacter = character.nameCharacter;
        hp = character.hp;
        isEnemy = character.isEnemy;
        isReady = character.isReady;
        isDead = character.isDead;
        foreach (var skill in character.skills)
        {
            skillsList.Add(skill);
        }
    }

    public void Die()
    {
        isDead = true;
        Debug.Log(nameCharacter + " погиб");
    }

    public void TakeDamage(int takenDamage)
    {
        hp -= takenDamage;
        if (hp <= 0)
        {
            Die();
        }
        else
        {
            Debug.Log(nameCharacter + " получил " + takenDamage + " урона");
        }
    }

    public bool IsEnemy()
    {
        return isEnemy;
    }

    public bool IsReady()
    {
        return isReady;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void SetAsNotReady()
    {
        isReady = false;
    }
}
