using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerHyper
{
    public class CameraFollow : MonoBehaviour
    {
        private Vector3 tempVec3 = new Vector3();
        [SerializeField]private Transform target;
        [SerializeField] private float yOffset;
        [SerializeField]private float zOffset;
        private void Start()
        {
            tempVec3= transform.position;
        }
        private void LateUpdate()
        {
            if (target == null) return;

            tempVec3.y = target.position.y + yOffset;
            tempVec3.z = target.position.z + zOffset;
            transform.position = tempVec3;

            transform.LookAt(target.position);
        }
    }
}
