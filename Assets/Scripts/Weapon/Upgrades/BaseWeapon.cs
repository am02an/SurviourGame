using UnityEngine;
using System.Collections;

public abstract class BaseWeapon : MonoBehaviour
{
    protected ActiveWeaponData data;
    protected Transform player;

    public virtual void Initialize(ActiveWeaponData weaponData, Transform owner)
    {
        data = weaponData;
        player = owner;

        StartCoroutine(AttackRoutine());
    }

    protected virtual IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(data.cooldown);
            Attack();
        }
    }

    protected abstract void Attack();
}
