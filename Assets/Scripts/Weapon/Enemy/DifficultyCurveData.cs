using UnityEngine;

[CreateAssetMenu(menuName = "Survivor/Difficulty Curve")]
public class DifficultyCurveData : ScriptableObject
{
    public AnimationCurve spawnRateCurve;
    public AnimationCurve enemyHealthMultiplier;
    public AnimationCurve enemyDamageMultiplier;

    public float maxGameTime = 600f;
}
