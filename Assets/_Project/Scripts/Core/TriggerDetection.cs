using UnityEngine;
namespace RunnerHyper
{
    public class TriggerDetection : MonoBehaviour
    {
        private UIManager uiManager;
        private void Start()
        {
            uiManager=(UIManager)FindObjectOfType(typeof(UIManager));
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.SetActive(false);
            }
            if (other.gameObject.CompareTag("Gold"))
            {
                other.gameObject.SetActive(false);
                uiManager.AddGold();
            }
        }
    }
}
