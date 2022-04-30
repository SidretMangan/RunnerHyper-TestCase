using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RunnerHyper
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Text secondsText;
        [SerializeField] private Text goldText;
        private int goldAmount=0;
        public int seconds = 60;
        private readonly WaitForSeconds wait = new WaitForSeconds(1f);
        
        private void Start()
        {
            StartCoroutine(TimeCountDown());
        }
        public void UpdateTime()
        {
            secondsText.text = seconds.ToString();
        }
        public void AddGold()
        {
            goldAmount++;
            goldText.text = goldAmount.ToString();
        }
        IEnumerator TimeCountDown()
        {
            while (true)
            {
                seconds--;
                UpdateTime();
                if (seconds <= 0) yield break;

                yield return wait;
            }
        }
    }
}
