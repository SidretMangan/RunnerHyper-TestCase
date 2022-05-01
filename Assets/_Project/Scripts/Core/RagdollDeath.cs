using UnityEngine;

namespace RunnerHyper
{
    public class RagdollDeath : MonoBehaviour
    {
        [SerializeField] private Animator animator = null;
        [SerializeField] private Rigidbody rbMain;
        [SerializeField] private CapsuleCollider colMain;
        private Rigidbody[] ragdollBodies;
        private Collider[] ragdollColliders;
        private void Start()
        {
            ragdollBodies = GetComponentsInChildren<Rigidbody>();
            ragdollColliders = GetComponentsInChildren<Collider>();

            ToggleRagdoll(false);
            ActivePlayer();
        }
        public void Die()
        {
            ToggleRagdoll(true);
            DeactivatePlayer();

            foreach (Rigidbody rb in ragdollBodies)
            {
                rb.AddExplosionForce(107f,new Vector3(-0.1f,0.25f,-0.25f),5f,0f,ForceMode.Impulse);
            }
        }
        private void ToggleRagdoll(bool state)
        {
            animator.enabled = !state;
            foreach (Rigidbody rb in ragdollBodies)
            {
                rb.isKinematic = !state;
            }
            foreach (Collider collider in ragdollColliders)
            {
                collider.enabled = state;
            }
            
        }
        private void ActivePlayer()
        {
            rbMain.isKinematic = false;
            colMain.enabled = true;
            rbMain.constraints= RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationZ;
            //rbMain.constraints = RigidbodyConstraints.FreezeRotationX;
        }
        private void DeactivatePlayer()
        {
            rbMain.constraints = RigidbodyConstraints.None;
            colMain.enabled = false;
        }
    }
}
