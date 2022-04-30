using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerHyper
{
    public class ApplicationInitializer : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
    }
}
