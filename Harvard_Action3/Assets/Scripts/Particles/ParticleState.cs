using UnityEngine;

namespace Game.Particles
{
    public class ParticleState : MonoBehaviour
    {
        private bool isSolidStat = false;
        private DistanceJoint2D particleDistantJoint;
        private Rigidbody2D particlesContainerRB;

        private void Awake() 
        {
            particleDistantJoint = GetComponent<DistanceJoint2D>();
            particlesContainerRB = GameObject.FindWithTag(Tags.PARTICLE_CONTAINER_TAG).GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            GetComponent<DistanceJoint2D>().connectedBody = particlesContainerRB;
            GetComponent<SpringJoint2D>().connectedBody = particlesContainerRB;
            GetComponent<WheelJoint2D>().connectedBody = particlesContainerRB;
            ChangeState();
        }

        // private void OnEnable()
        // {
        //     EventHandler.StateChangeActionEvent += ChangeState;
        // }

        // private void OnDisable()
        // {
        //     EventHandler.StateChangeActionEvent -= ChangeState;
        // }

        private void ChangeState()
        {
            //Debug.Log("State Change");
            particleDistantJoint = GetComponent<DistanceJoint2D>();
            if (isSolidStat)
            {
                isSolidStat = false;
                particleDistantJoint.distance = 0.3f;
                particleDistantJoint.maxDistanceOnly = false;
            }
            else
            {
                isSolidStat = true;
                particleDistantJoint.distance = 0.6f;
                particleDistantJoint.maxDistanceOnly = true;
            }
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if (other.gameObject.CompareTag(Tags.WILD_PARTICLE_TAG) ) 
            {
                EventHandler.CallAddParticleEvent();
                Destroy(other.gameObject);
            }
        }
    }
}

