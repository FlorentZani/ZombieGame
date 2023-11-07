public class AR15 : Gun
{
    public override void Shoot()
    {
        if (CanShoot)
        {
            SoundManager.Instance.PlaySound("AR15");
        }
        base.Shoot();
    }
}
