using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControls : MonoBehaviour
{
    public Transform muzzle;
    public RectTransform crossHair;
    public Camera mainCamera;
    public float range;
    bool somethingHit;
    RaycastHit hitInfo;
    public LayerMask ignoreLayer;
    public GameObject bullet;
    public float speed;
    public float scaleFactor = 1;
    public float Damage;
    public int MaxAmmo=10;
    public int CurrentAmmo;
    public float reloadTime=1f;
    public bool isReloading=false;
    public int ClipCount=2;

    // Start is called before the first frame update
    void Start()
    {
        CurrentAmmo =MaxAmmo;
    }
    void SetCrossHair()
    {
        somethingHit = Physics.Raycast(muzzle.position, muzzle.forward, out hitInfo , range, ~ignoreLayer);
        if (somethingHit)
        {
            crossHair.gameObject.SetActive(true);
            Vector3 hitPoint = hitInfo.point;
            Vector3 positionInCamera = mainCamera.WorldToScreenPoint(hitPoint);
            crossHair.anchoredPosition = new Vector2(positionInCamera.x, positionInCamera.y);
            crossHair.localScale = new Vector3(1,1,1) * scaleFactor/hitInfo.distance;

        }
        else
        {
            crossHair.gameObject.SetActive(false);
        }
    }
    void Shoot()
    {
        GameObject bulletClone =Instantiate(bullet, muzzle.position, Quaternion.identity);
        bulletClone.GetComponent<BulletBehaviour>().SetVelocity(muzzle.forward.normalized * speed);
        bulletClone.GetComponent<BulletBehaviour>().SetDamage(Damage);
        CurrentAmmo--;

    }

    IEnumerator  Reload()
    {
        isReloading=true;
        yield return new WaitForSeconds(reloadTime);
        CurrentAmmo=MaxAmmo;
        isReloading=false;
        ClipCount--;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isReloading)
        {
            return;
        }
        SetCrossHair();
        if (Input.GetMouseButtonDown(0) && crossHair.gameObject.activeSelf && CurrentAmmo>0)
        {
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R)&&CurrentAmmo<MaxAmmo&&ClipCount>0)
        {
            StartCoroutine(Reload());
        }
    }
}
