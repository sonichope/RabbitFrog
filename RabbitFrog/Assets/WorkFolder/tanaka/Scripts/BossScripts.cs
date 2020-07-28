using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScripts : MonoBehaviour
{
    [Header("キャラクター画像")] public Sprite image;          // キャラクター画像
    [Header("体力")] public int hp;                            // 体力
    [Header("攻撃力")] public int power;                       // 攻撃力

    public bool IsDeath { get; set; } = false;

    /// <summary>
    /// 攻撃範囲
    /// </summary>
    public virtual void AttackRange() { }

    private void Update()
    {
        hp--;
    }
}
