using System;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts
{
    public class Enemy : MonoBehaviour
    {
        private GameObject _target;
        [SerializeField] private int live = 100;
        [SerializeField] private Animator animationBoss;
        private void OnEnable()
        {
            _target = GameObject.Find("Target");
        }
        private void Start()
        {
            if (_target!=null)
            {
                GetComponent<NavMeshAgent>().SetDestination(_target.transform.position);
                animationBoss = GetComponent<Animator>();
                animationBoss.SetBool("IsMoving",true);
            }
            else
            {
                print("error");
            }

        }



        private void OnDisable()
        {
        }
        private void Update()
        {
        
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Target"))
            {
                animationBoss.SetBool("IsMoving",false);
                animationBoss.SetTrigger("OnObjectLiveReached");
            }
        }

        private void Damage()
        {
            _target?.GetComponent<Target>().RecibeDamage(2);
        }
        
        private void RecibeDamage(int damage=20)
        {
            live-=damage;
        }

    }
}
