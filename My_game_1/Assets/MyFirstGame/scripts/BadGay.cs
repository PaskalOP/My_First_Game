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
        //private Vector3 _directionBG;
        //public float speed = 2f;


        void Start()
        {
            _player = FindObjectOfType<player>();

        }


        void Update()
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < 5)
            {
                //if (Input.GetButton("Fire"))
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

               
        }
       
    }
}

