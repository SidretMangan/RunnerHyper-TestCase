using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RunnerHyper
{
    public class CharacterMovement : MonoBehaviour
    {
        #region Animation
        [SerializeField] private Animator animator;
        private int runningAnimHash;
        private int skillAnimHash;
        #endregion
        #region Input
        private PlayerActions playerActions;
        #endregion
        #region Input Values
        private Vector2 currentMovement;
        private Vector3 currentPosition;
        private Vector3 newPosition;
        private Vector3 positionToLookAt;

        private bool skillOnePressed;
        private bool skillTwoPressed;
        private bool skillThreePressed;
        [SerializeField]private Rigidbody rb;
        private bool isMoving;
        #endregion
        #region Particle
        [SerializeField] private ParticlePool particlePool;
        #endregion
        private void Awake()
        {
            playerActions = new PlayerActions();
        }
        private void OnEnable()
        {
            playerActions.PlayerActionMap.Enable();
        }
        private void Start()
        {
            runningAnimHash = Animator.StringToHash("isRunning");
            skillAnimHash = Animator.StringToHash("usingSkill");

            SetInputEvents();
        }
        private void SetInputEvents()
        {
            playerActions.PlayerActionMap.Movement.performed += ctx =>
            {
                currentMovement = ctx.ReadValue<Vector2>();
                currentMovement.y = (currentMovement.y < 0) ? 0 : currentMovement.y;
                animator.SetBool(runningAnimHash, true);
                isMoving = true;
                HandleRotation();
            };
            playerActions.PlayerActionMap.Movement.canceled += ctx =>
            {
                animator.SetBool(runningAnimHash, false);
                isMoving = false;
            };
            playerActions.PlayerActionMap.SkillOne.performed += ctx =>
            {
                if (ctx.ReadValueAsButton())
                {
                    animator.SetTrigger(skillAnimHash);
                    particlePool.CallSkill(0);
                }
            };
            playerActions.PlayerActionMap.SkillTwo.performed += ctx =>
            {
                if (ctx.ReadValueAsButton())
                {
                    animator.SetTrigger(skillAnimHash);
                    particlePool.CallSkill(1);
                }
            };
            playerActions.PlayerActionMap.SkillThree.performed += ctx => 
            {
                if (ctx.ReadValueAsButton())
                {
                    animator.SetTrigger(skillAnimHash);
                    particlePool.CallSkill(2);
                }
            };
        }
        private void HandleRotation()
        {
            //currentPosition = transform.position;
            currentPosition = rb.position;
            newPosition =new Vector3(currentMovement.x, 0, currentMovement.y);
            positionToLookAt = currentPosition + newPosition;
            transform.LookAt(positionToLookAt);
        }
        private void OnDisable()
        {
            playerActions.PlayerActionMap.Disable();
        }

        private void FixedUpdate()
        {
            if (!isMoving) return;

            rb.AddRelativeForce(Vector3.forward * 12, ForceMode.Impulse);
        }
    }
}
