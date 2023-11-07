public class Handgun : Gun
{
    public override void Shoot()
    {
        if (CanShoot)
        {
            SoundManager.Instance.PlaySound("HandGun");
        }
        base.Shoot();
    }
}
