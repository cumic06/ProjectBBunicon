using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;

    private void Start()
    {
        transform.LookAt2D(Player.Instance.transform.position);
        UpdateSystem.Instance.AddFixedUpdateAction(Move);
    }

    public void SetAttackPower(int bulletDamage)
    {
        this.bulletDamage = bulletDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable unit))
        {
            HpManager.Instance.TakeDamage(unit, bulletDamage);
            UpdateSystem.Instance.RemoveFixedUpdateAction(Move);
            Destroy(gameObject);
        }
    }

    protected virtual void Move()
    {
        transform.Translate(bulletSpeed * Time.deltaTime * Vector2.right);
    }
}
