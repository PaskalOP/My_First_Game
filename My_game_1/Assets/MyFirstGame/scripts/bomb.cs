using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace firstGame
{
    public class bomb : MonoBehaviour
    {
        [SerializeField] private player hiro;

    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(hiro);
            }

        }
    }

}
