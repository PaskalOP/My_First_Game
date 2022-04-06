using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace firstGame
{
    public class WayPatrol : MonoBehaviour
    {
        public NavMeshAgent _navMeshAgent;
        public Transform[] pointOfPatrol;
        [SerializeField] private bool _playerIsNotFind;
        [SerializeField] private player _player;


        int m_CurrentPointIndex;

        void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
           
            _player = FindObjectOfType<player>();
            _playerIsNotFind = true;
        }

        void Start()
        {
            
            StartCoroutine(FindPlayer());
         
        }


        void Update()
        {


            if (Vector3.Distance(_player.transform.position, transform.position) <= 5)
            {
                _playerIsNotFind = false;
                StopCoroutine(FindPlayer());
            }
            if (Vector3.Distance(_player.transform.position, transform.position) > 5)
            {
                _playerIsNotFind = true;
                StartCoroutine(FindPlayer());
            }
        }
        IEnumerator FindPlayer()
        {
               
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                m_CurrentPointIndex = (m_CurrentPointIndex + 1) % pointOfPatrol.Length;
               _navMeshAgent.SetDestination(pointOfPatrol[m_CurrentPointIndex].position);
            }
            yield return new WaitWhile(() => _playerIsNotFind);
        }
    }

}



