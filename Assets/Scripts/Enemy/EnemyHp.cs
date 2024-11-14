using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] private int _hp = 1000;
    // bool isTakingDamage = false;
    public int Hp { get { return _hp; } 
        set { _hp = value; 
            if (_hp < 0)
            {
                Destroy(this.gameObject);
            }
            } }

    public void TakeDamage(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            Destroy(this.gameObject, 0.5f);
        }
    }
}
