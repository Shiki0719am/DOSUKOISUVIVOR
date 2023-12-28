using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    // 親の生成装置
    protected BaseWeaponSpawner spawner;
    // 武器ステータス
    protected WeaponSpawnerStats stats;
    protected Rigidbody2D rigidbody2d;
    // 方向
    protected Vector2 forward;

    // 初期化
    public void Init(BaseWeaponSpawner spawner, Vector2 forward)
    {
        // 親の生成装置
        this.spawner = spawner;
        // 武器データセット
        this.stats = (WeaponSpawnerStats)spawner.Stats.GetCopy();
        // 進む方向
        this.forward = forward;
        // 物理挙動
        this.rigidbody2d = GetComponent<Rigidbody2D>();

        // 生存時間があれば設定する
        if (-1 < stats.AliveTime)
        {
            Destroy(gameObject, stats.AliveTime);
        }
    }

    // 敵へ攻撃
    protected void AttackEnemy(Collider2D collider2d, float attack)
    {
        // 敵じゃない
        if (!collider2d.gameObject.TryGetComponent<EnemyController>(out var enemy)) return;
        float damage = enemy.Damage(attack);
    }
}
