using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace firstGame
{
    public class Bullet : MonoBehaviour
    {
        private Transform _target;
        [SerializeField] private float _speed=3;
        [SerializeField] private float _damage=3;
        

        public void Init(Transform target,  float lifeTime, float speed)
        {
            _target = target;
            _speed = speed;
            Destroy(gameObject, lifeTime);
        }

        void FixedUpdate()
        {
            //transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
            transform.position += transform.forward * _speed * Time.fixedDeltaTime;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
            {
                takeDamage.Hit(_damage);
                Destroy(gameObject);
                             
            }
        }
    }
}

