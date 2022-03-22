using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace firstGame
{
    public class Friend : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }

        }
    }
}

