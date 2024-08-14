using System;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts
{
    public class Boss : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        [SerializeField] private int live = 100;
        [SerializeField] private Animator animationBoss;
        private void Start()
        {
            GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
            animationBoss = GetComponent<Animator>();
            animationBoss.SetBool("IsMoving",true);
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
            target?.GetComponent<Target>().RecibeDamage(2);
        }
        
        private void RecibeDamage(int damage=5)
        {
            live-=damage;
        }

    }
}
