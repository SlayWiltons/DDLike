using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Hero : MonoBehaviour, IDamageable<int>, IKillable
{
    [SerializeField] private Character character;
    private int hp;
    private bool isEnemy;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = character.sprite;
        hp = character.hp;
        isEnemy = character.isEnemy;
    }

    public void Die()
    {
        Debug.Log("Меня убили!");
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
            Debug.Log("Мне нанесли: " + takenDamage + " урона");
        }
    }
}
