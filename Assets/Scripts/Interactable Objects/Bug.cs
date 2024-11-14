using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    [SerializeField] private int _hp = 3;
    public int Hp { get { return _hp; } 
        set { _hp = value; 
            if (_hp <= 0)
            {
                Destroy(this.gameObject);
            }
            } }
    public void TakeDamage(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
