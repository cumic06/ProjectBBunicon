using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    protected Monster monster;
    protected MonsterAttack monsterAttack;
    protected MonsterMove monsterMove;

    protected void Awake()
    {
        monster = GetComponent<Monster>();
        monsterAttack = GetComponent<MonsterAttack>();
        monsterMove = GetComponent<MonsterMove>();
    }

    protected void Start()
    {
        monsterAttack.SetAttackPower(monster.GetUnitData().unitStat.attackPower);
        monsterAttack.SetAttackDelayTime(monster.GetUnitData().unitStat.attackDelayTime);
        monsterAttack.SetAttackRange(monster.GetUnitData().unitStat.attackRange);
    }

    public void AI()
    {
        if (IsCanAttackRange(out Collider2D[] players))
        {
            monsterAttack.currentAttackDelayTime += Time.deltaTime;

            if (monsterAttack.IsCanAttack())
            {
                monsterAttack.Attack();
                monsterAttack.currentAttackDelayTime = 0;
                //#if UNITY_EDITOR
                //                Debug.Log("Attack");
                //#endif
            }
        }
        else
        {
            //#if UNITY_EDITOR
            //            Debug.Log("FollowPlayer");
            //#endif
            FollowPlayer();
        }
    }

    protected void FollowPlayer()
    {
        if (Player.Instance == null) return;
        Vector3 dir = Player.Instance.transform.position - transform.position;
        float speed = monster.GetCurrentMoveSpeedStat();
        Vector3 moveVec = speed * dir.normalized;
        transform.Translate(moveVec * Time.deltaTime);
    }

    public virtual bool IsCanAttackRange(out Collider2D[] player)
    {
        Collider2D[] checkCircle = Physics2D.OverlapCircleAll(transform.position, monster.AttackRange, LayerMaskManager.playerLayer);
        player = checkCircle;
        return checkCircle.Length > 0;
    }

    protected virtual void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, monster.AttackRange);
        }
    }
}