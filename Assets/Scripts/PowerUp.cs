using UnityEngine;
public abstract class PowerUp : BaseTarget
{
    public abstract void TriggerPower(float amount);
    public override void TakeDamage(float amount)
    {
        TriggerPower(amount);
        DestroyPowerUp();
    }

    protected virtual void DestroyPowerUp()
    {
        Destroy(this.gameObject);
    }
}
