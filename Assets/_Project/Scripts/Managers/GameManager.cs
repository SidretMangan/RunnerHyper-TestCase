using System.Collections;
using UnityEngine;

namespace RunnerHyper
{
    public class GameManager : MonoBehaviour
    {
        #region Managers
        private PoolManager poolManager;
        private UIManager uiManager;
        #endregion
        private readonly WaitForSeconds wait = new WaitForSeconds(0.5f);
        private Camera cam;
        private RagdollDeath playerDeath;
        private void Start()
        {
            poolManager = (PoolManager)FindObjectOfType(typeof(PoolManager));
            uiManager = (UIManager)FindObjectOfType(typeof(UIManager));
            StartCoroutine(CallPoolObjs());
            cam=Camera.main;
            playerDeath=(RagdollDeath)FindObjectOfType(typeof(RagdollDeath));
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
                if (uiManager.seconds <= 1) 
                {
                    playerDeath.Die();
                    cam.gameObject.GetComponent<CameraFollow>().enabled = false;
                    yield break; 
                }

                yield return wait;
            }
        }

    }
}
