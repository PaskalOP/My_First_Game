using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace firstGame
{
    public class door : MonoBehaviour
    {
        [SerializeField] private Transform _rotatePoint;
        [SerializeField] private Animator _anim;

        void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
           if (other.CompareTag("Player")|| other.CompareTag("BadGay"))
            {
                // _rotatePoint.Rotate(Vector3.down, 90);

                _anim.SetBool("open door", true);
            }

        }
        private void OnTriggerExit (Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("BadGay"))
            {
                // _rotatePoint.Rotate(Vector3.up, 90);
                _anim.SetBool("open door", false);
            }

        }
    }

}
