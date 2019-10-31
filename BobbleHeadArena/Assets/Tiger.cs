using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Tiger : MonoBehaviour
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
    public Transform cubeTest;
    public Transform snapTest;


    // Use this for initialization
    void Start()
    {
        cubeTest.parent = snapTest;
        cubeTest.position = snapTest.position;

        // to unparent:
        //cubeTest.parent = null;
        
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
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
                    //play attack animation
                    //anim.SetBool("walk", false);
                }
                else
                {
                   
                    anim.SetBool("walk", true);
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
        if (isAlive && other.tag == "Player")
        {
            //Do something nice for player
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
        }
        else if (isAlive && other.tag == "enemy")
        {
            Destroy(other.gameObject);
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
