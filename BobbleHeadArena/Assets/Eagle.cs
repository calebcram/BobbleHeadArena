using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class Eagle : MonoBehaviour
{
    public Transform target;
    public float navigationUpdate;
    public UnityEvent OnDestroy;
    Animator anim;
    //public Rigidbody head;
    public bool isAlive = true;
    private float navigationTime = 0;
    private NavMeshAgent agent;
    private DeathParticles deathParticles;

    // Use this for initialization
    void Start()
    {
        GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (target != null)
            {
                if (agent.remainingDistance < 1)
                    
                {
                    anim.SetBool("move", false);
                    //play attack animation
                }
                else
                {
                    anim.SetBool("move", true);
                    //play move animation
                }
                navigationTime += Time.deltaTime;
                if (navigationTime > navigationUpdate)
                {
                    agent.destination = target.position;
                    navigationTime = 0;
                }
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (isAlive)
        {
            Die();
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
        }
    }

    public void Die()
    {
        isAlive = false;
        //head.GetComponent<Animator>().enabled = false;
        //head.isKinematic = false;
        //head.useGravity = true;
        //head.GetComponent<SphereCollider>().enabled = true;
        //head.gameObject.transform.parent = null;
        //head.velocity = new Vector3(0, 6.0f, 3.0f);
        OnDestroy.Invoke();
        OnDestroy.RemoveAllListeners();
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
        //head.GetComponent<SelfDestruct>().Initiate();
        if (deathParticles)
        {
            deathParticles.transform.parent = null;
            deathParticles.Activate();
        }
        Destroy(gameObject);
    }

    public DeathParticles GetDeathParticles()
    {
        if (deathParticles == null)
        {
            deathParticles = GetComponentInChildren<DeathParticles>();
        }
        return deathParticles;
    }
}
