using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerHyper
{
    public class CameraFollow : MonoBehaviour
    {
        private Vector3 tempVec3 = new Vector3();
        [SerializeField]private Transform target;
        [SerializeField][Range(0.01f, 1f)] private float smoothSpeed;
        [SerializeField] private float yOffset;
        [SerializeField]private float zOffset;
        private Vector3 velocity = Vector3.zero;
        private void Start()
        {
            tempVec3= transform.position;
        }
        private void LateUpdate()
        {
            if (target == null) return;

            tempVec3.y = target.position.y + yOffset;
            tempVec3.z=target.position.z+zOffset;
            transform.position = Vector3.SmoothDamp(transform.position, tempVec3, ref velocity, smoothSpeed);
            transform.LookAt(target.position);
        }
    }
}
