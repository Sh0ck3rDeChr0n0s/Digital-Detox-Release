using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brizg : MonoBehaviour
{

    private EnemyHp _enemy;
    private bool _isBrizg = false;
    public int damage = 1;

    void Update()
    {
        if (_enemy.IsDestroyed())
        {
            Debug.Log("killed");
            _enemy = null;
            _isBrizg = false;
        }
        if (_isBrizg)
        {
            print(_enemy.Hp);
            _enemy.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("y");
        if (other.CompareTag("Enemy"))
        {
            _enemy = other.GetComponent<EnemyHp>();
            _isBrizg = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _isBrizg = false;
        }
    }
}
