using UnityEngine;

namespace Game.Particles
{
    public class ParticleState : MonoBehaviour
    {
        private bool isSolidStat = false;
        private DistanceJoint2D particleDistantJoint;
        private SpringJoint2D particleSpringJoint;
        private WheelJoint2D particleWheelJoint;
        private Rigidbody2D particleRB;
        private Rigidbody2D particlesContainerRB;
        private ConstantForce2D particlesConstantForce;

        private void Awake() 
        {
            particleDistantJoint = GetComponent<DistanceJoint2D>();
            particleSpringJoint = GetComponent<SpringJoint2D>();
            particleWheelJoint = GetComponent<WheelJoint2D>();
            particlesConstantForce = GetComponent<ConstantForce2D>();
            particleRB = GetComponent<Rigidbody2D>();

            particlesContainerRB = GameObject.FindWithTag(Tags.PARTICLE_CONTAINER_TAG).GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            particleDistantJoint.connectedBody = particlesContainerRB;
            particleSpringJoint.connectedBody = particlesContainerRB;
            particleWheelJoint.connectedBody = particlesContainerRB;
            //ChangeState();
        }

        private void OnEnable()
        {
            EventHandler.ParticleBreakEvent += BreakJoints;
        }

        private void OnDisable()
        {
            EventHandler.ParticleBreakEvent -= BreakJoints;
        }

        private void BreakJoints()
        {
            particleRB.gravityScale = 2f;
            particleDistantJoint.enabled = false;
            particleSpringJoint.enabled = false;
            particleWheelJoint.enabled = false;
            particlesConstantForce.force = new Vector2 (25f, 0f);

        }

        private void ChangeState()
        {
            Debug.Log("State Change");
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

