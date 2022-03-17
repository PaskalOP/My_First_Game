using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace firstGame
{
    public class SpawnerBG : MonoBehaviour
    {
        [SerializeField] Transform spawnPoint;
        public GameObject badGay;


        void Start()
        {

            StartCoroutine(SpawnBadGay());
        }

        void Update()
        {

        }
        void Repeat()
        {
            StartCoroutine(SpawnBadGay());
        }
        IEnumerator SpawnBadGay()
        {
            yield return new WaitForSeconds(30f);
            Instantiate(badGay, spawnPoint.position, Quaternion.identity);
            Repeat();
        }
    }

}
