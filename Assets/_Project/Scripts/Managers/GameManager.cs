using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerHyper
{
    public class GameManager : MonoBehaviour
    {
        private PoolManager poolManager;
        private UIManager uiManager;
        private readonly WaitForSeconds wait = new WaitForSeconds(0.5f);
        private void Start()
        {
            poolManager = (PoolManager)FindObjectOfType(typeof(PoolManager));
            uiManager = (UIManager)FindObjectOfType(typeof(UIManager));
            StartCoroutine(CallPoolObjs());
        }
        private void CallPoolObj()
        {
            int objType = Random.Range(0, 2);
            poolManager.GetPooledObject(objType);
        }
        private IEnumerator CallPoolObjs()
        {
            while (true)
            {
                CallPoolObj();
                if (uiManager.seconds <= 2) yield break;

                yield return wait;
            }
        }

    }
}
