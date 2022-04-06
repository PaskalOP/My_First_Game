using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace firstGame
{
    public class door : MonoBehaviour
    {
        [SerializeField] private Transform _rotatePoint;

        private void OnTriggerEnter(Collider other)
        {
           if (other.CompareTag("Player")|| other.CompareTag("BadGay"))
            {
                _rotatePoint.Rotate(Vector3.down, 90);
            }

        }
        private void OnTriggerExit (Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("BadGay"))
            {
                _rotatePoint.Rotate(Vector3.up, 90);
            }

        }
    }

}
