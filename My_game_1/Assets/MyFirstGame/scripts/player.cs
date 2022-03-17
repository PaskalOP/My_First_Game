using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace firstGame
{
    public class player : MonoBehaviour
    {
        public GameObject shildPrefab;
        public Transform shildPoint;
        private bool _isSpawnShild;
        private int level = 1;
        private Vector3 _direction;
       // private Vector3 jump;
        
        public float speed = 2f;
        private bool _isSprint;
        
        private void Awake()
        {
            
        }
       
        void Start()
        {
            
        }

        
        void Update()
        {
            if (Input.GetButtonDown("shild hiro"))
                _isSpawnShild = true;

            _direction.z = Input.GetAxis("Vertical");

            _direction.x = Input.GetAxis("Horizontal");

            // jump.y = Input.GetAxis("Jump");

            _isSprint = Input.GetButton("Sprint");

            
               
            
        }
        
        private void SpawnShildPoint()
        {
            var shildOb = Instantiate(shildPrefab, shildPoint.position, shildPoint.rotation);
           var shild = shildOb.GetComponent<shild>();
            shild.Init(10* level);
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
            //JumpPlayer(Time.fixedDeltaTime);
            //JumpPlayer();

        }
        private void Move(float delta)
        {
            transform.position += _direction * (_isSprint? speed*3: speed) *delta;
            
        }

       /* private void JumpPlayer()
        {
            
            transform.position += jump * 10;
            transform.position -= jump * 10;
            

        }*/
    }
}

