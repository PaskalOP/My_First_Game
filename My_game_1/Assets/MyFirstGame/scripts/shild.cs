using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace firstGame
{
    public class shild : MonoBehaviour
    {
        private float _durability;

        // Start is called before the first frame update
        public void Init(float _durability)
        {
            Destroy(gameObject, 3f);
        }


    }
}

