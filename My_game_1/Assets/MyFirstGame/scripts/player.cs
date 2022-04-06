using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace firstGame
{
    public class player : MonoBehaviour
    {
        public GameObject shildPrefab;
        public GameObject friend;
        public Transform shildPoint;
        private bool _isSpawnShild;
        private int level = 1;
        [SerializeField]private int countOfFriend = 0;
        private Vector3 _direction;
        //[SerializeField] private int HP = 10;


        public float speed = 2f;
        public float _speedRotate = 200;
        public float _jumpForce = 5;
        private bool _isSprint;

        void Start()
        {

        }


        void Update()
        {
            if (Input.GetButtonDown("shild hiro"))
                _isSpawnShild = true;

            _direction.z = Input.GetAxis("Vertical");

            _direction.x = Input.GetAxis("Horizontal");



            _isSprint = Input.GetButton("Sprint");

           if(Input.GetButtonDown("Jump"))
                GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);


        }

        private void SpawnShildPoint()
        {
            var shildOb = Instantiate(shildPrefab, shildPoint.position, shildPoint.rotation);
            var shild = shildOb.GetComponent<shild>();
            shild.Init(10 * level);
            shild.transform.SetParent(shildPoint);
        }

        private void FixedUpdate()
        {
            if (_isSpawnShild)
            {
                _isSpawnShild = false;
                SpawnShildPoint();
            }
            Move(Time.fixedDeltaTime);

            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * _speedRotate * Time.fixedDeltaTime, 0));
        }
        private void Move(float delta)
        {
            var transfDir = transform.TransformDirection(_direction.normalized);
            transform.position += transfDir * (_isSprint ? speed * 3 : speed) * delta;

        }
       
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Frend"))
            {
                countOfFriend++;
            }

        }
    }  
}

