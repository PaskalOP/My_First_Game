using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace firstGame
{
    public class Trap : MonoBehaviour
    {
        [SerializeField] private float _coolDown;
        
        void MoveDownUp()
        {
          

                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
          
        }
        void MoveDown()
        {
            transform.position = new Vector3(transform.position.x, -8, transform.position.z);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                Invoke(nameof(MoveDown), _coolDown);
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                Invoke(nameof(MoveDownUp), _coolDown);
        }
    }
}

