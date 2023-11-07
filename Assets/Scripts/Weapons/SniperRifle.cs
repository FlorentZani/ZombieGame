using UnityEngine;

public class SniperRifle : Gun
{
    public bool isZoomMode = false;
    [SerializeField]
    GameObject camera1 = null;

    [SerializeField]
    GameObject camera2 = null;

    [SerializeField]
    GameObject crosshair1 = null;

    [SerializeField]
    GameObject crosshair2 = null;

    [SerializeField]
    GameObject panel = null;

    [SerializeField]
    MeshRenderer meshRenderer;

    public override void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            isZoomMode = !isZoomMode;
            ToggleZoomMode();
        }

        base.Update();
    }

    public override void Shoot()
    {
        if (CanShoot)
        {
            SoundManager.Instance.PlaySound("SniperRifle");
        }
        base.Shoot();
    }

    void ToggleZoomMode()
    {
        crosshair1.SetActive(!isZoomMode);
        crosshair2.SetActive(isZoomMode);
        camera1.tag = !isZoomMode ? "MainCamera" : "Untagged";
        camera2.tag = isZoomMode ? "MainCamera" : "Untagged";
        camera2.SetActive(isZoomMode);
        panel.SetActive(isZoomMode);
        meshRenderer.enabled = !isZoomMode;
    }
}
