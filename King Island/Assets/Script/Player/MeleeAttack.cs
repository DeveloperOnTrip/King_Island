using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeAttack : MonoBehaviour
{
    public Animator _anim;

    public Transform _attackPoint;
    public float _attackRange = 0.4f;
    public LayerMask _enmeyLayers;
    bool _isAttacking = false;

    public float _attackRate = 2f;
    float _nextAttackTime = 0;

    public void Attack(InputAction.CallbackContext context)
    {
        if (Time.time >= _nextAttackTime)
        {
            if (context.performed)
            {
                GoAttack();
                _nextAttackTime = Time.time + 1f / _attackRate;
            }
        }
    }

    void GoAttack()
    {
        _anim.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enmeyLayers);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            hitEnemies[i].GetComponent<BoxHealth>().DestroyMe();
        }
    }

    private void OnDrawGizmos()
    {
        if (_attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
