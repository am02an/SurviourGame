using UnityEngine;

public class SoccerBallWeapon : BaseWeapon
{
    public GameObject ballPrefab;

    public override void Initialize(ActiveWeaponData weaponData, Transform playerTransform)
    {
        base.Initialize(weaponData, playerTransform);
        ballPrefab = weaponData.weaponPrefab;
    }

    protected override void Attack()
    {
        if (ballPrefab == null) return;

        GameObject ball = Instantiate(
            ballPrefab,
            player.position,
            Quaternion.identity);

        SoccerBallProjectile proj = ball.GetComponent<SoccerBallProjectile>();

        if (proj != null)
            proj.Initialize(data.projectileSpeed, data.damage);
    }
   
}
