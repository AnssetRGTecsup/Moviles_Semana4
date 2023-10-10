using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingController : MonoBehaviour
{
    [SerializeField] private SimpleObjectPooling myPooling;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private bool canShoot;
    public NohacerEnCasa eliminar;

    private float _count = 0f;
    private int _countBullets = 0;

    private void Awake()
    {
        myPooling.SetUp(this.transform);
        myPooling.onEnableObject += PrintBulletCount;
    }

    private void OnDisable()
    {
        myPooling.onEnableObject -= PrintBulletCount;
    }

    private void FixedUpdate()
    {
        _count += Time.deltaTime;

        if(_count > fireRate && canShoot)
        {
            myPooling.GetObject();

            _count = 0;
        }
    }

    private void PrintBulletCount()
    {
        _countBullets++;
        Debug.Log(gameObject.name + ": " + _countBullets);
    }
}
