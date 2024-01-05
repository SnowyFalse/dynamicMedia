using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class RingbufferFootSteps : MonoBehaviour
{
    public ParticleSystem system;
    public NavMeshAgent agent;
    public Material activeMat;
    public Material selectedMat;
    public Material activeParticleMat;
    public Material selectedParticleMat;

    Vector3 lastEmit;

    public float delta = 1;
    public float gap = 0.5f;
    int dir = 1;
    static RingbufferFootSteps selectedSystem;

    void Start()
    {
        Vector3 randomPos = new Vector3(Random.Range(-10f, 10f), 0, 0);

        Debug.Log("Random: "+ randomPos);
        lastEmit = transform.position;
        GetComponent<MeshRenderer>().material = activeMat;
        agent.SetDestination(randomPos);
        agent.isStopped = false;


    }

    public void Update()
    {

        if (Vector3.Distance(lastEmit, transform.position) > delta)
        {
            Gizmos.color = Color.green;
            var pos = transform.position + (transform.right * gap * dir);
            dir *= -1;
            ParticleSystem.EmitParams ep = new ParticleSystem.EmitParams();
            ep.position = pos;
            ep.rotation = transform.rotation.eulerAngles.y;
            system.Emit(ep, 1);
            lastEmit = transform.position;
        }
        Destroy(gameObject, 5.0f);
    }

    public void OnMouseUpAsButton()
    {
        if (selectedSystem == this)
            return;

        if (selectedSystem != null)
        {
            selectedSystem.agent.isStopped = true;
            selectedSystem.GetComponent<Renderer>().material = activeMat;
            selectedSystem.system.GetComponent<Renderer>().material = activeParticleMat;
        }

        selectedSystem = this;
        GetComponent<Renderer>().material = selectedMat;
        system.GetComponent<Renderer>().material = selectedParticleMat;
    }
}
