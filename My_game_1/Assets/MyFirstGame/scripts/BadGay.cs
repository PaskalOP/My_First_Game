using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

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
        public NavMeshAgent _agent;
       
        



        void Awake()
        {
            _player = FindObjectOfType<player>();
            _agent = GetComponent<NavMeshAgent>();
           


        }
        private void Start()
        {
            // _agent.SetDestination(_player.transform.position);
         
        }

        void Update()
        {

            
            Ray ray01 = new Ray(PointOfBullet.position, transform.forward);
            if (Physics.SphereCast(ray01, 5, out RaycastHit hit))

                if (hit.collider.CompareTag("Player"))
                {

                    var direcnion = _player.transform.position - transform.position;
                    var stepRotate = Vector3.RotateTowards(transform.forward, direcnion, _speedRotate * Time.fixedDeltaTime, 3f);
                    transform.rotation = Quaternion.LookRotation(stepRotate);
                    _agent.SetDestination(_player.transform.position);

                    if (_isFire)
                        Fire();

                }
                
       
        }
       

         void Fire()
        {
            _isFire = false;
            var bulletOb = Instantiate(bulletPref, PointOfBullet.position, PointOfBullet.rotation);
                var bullet = bulletOb.GetComponent<Bullet>();
                bullet.Init(_player.transform, 2, 10f);
                
            Invoke(nameof(Reloading), _coolDown);


        }
        void Reloading()
        {
            _isFire = true;
        }

       
    }
}

