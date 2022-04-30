using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerHyper
{
    public class ParticlePool : MonoBehaviour
    {
        [SerializeField]private GameObject[] skillParticles;

        public void CallSkill(int number)
        {
            skillParticles[number].SetActive(true);
        }
    }
}
