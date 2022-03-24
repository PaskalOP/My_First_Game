using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace firstGame
{
    public class BadGay : MonoBehaviour
    {
        [SerializeField] private player _player;
        [SerializeField] private GameObject bulletPref;
        [SerializeField] private Transform PointOfBullet;
        [SerializeField] private float _speedRotate;
        [SerializeField] private float _coolDown;
        [SerializeField] private bool _isFire;
       


        void Start()
        {
            _player = FindObjectOfType<player>();

        }


        void Update()
        {
            Ray ray01 = new Ray(PointOfBullet.position, transform.forward);
            if(Physics.Raycast(ray01,out RaycastHit hit,5))

                if (hit.collider.CompareTag("Player"))
                {
                    if (_isFire)
                        Fire();
                }

          var direcnion = _player.transform.position - transform.position;
            var stepRotate = Vector3.RotateTowards(transform.forward, direcnion, _speedRotate * Time.fixedDeltaTime, 0f);
          transform.rotation = Quaternion.LookRotation(stepRotate);


        }
         void Fire()
        {
                var bulletOb = Instantiate(bulletPref, PointOfBullet.position, PointOfBullet.rotation);
                var bullet = bulletOb.GetComponent<Bullet>();
                bullet.Init(_player.transform, 10, 2f);
            _isFire = false;
            Invoke(nameof(Reloading), _coolDown);


        }
        void Reloading()
        {
            _isFire = true;
        }
       
    }
}

