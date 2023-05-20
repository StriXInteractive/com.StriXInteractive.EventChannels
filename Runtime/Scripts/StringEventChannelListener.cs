using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace StriXInteractive.Tools.EventChannels {
    public class StringEventChannelListener : MonoBehaviour {

        [SerializeField] private StringEventChannelSO eventChannel;
        [SerializeField] private UnityEvent<string> response;
        [SerializeField] private float delay;

        private void OnEnable() {
            if (eventChannel != null) {
                eventChannel.OnEventRaised += OnEventRaised;
            }
        }

        private void OnDisable() {
            if (eventChannel != null) {
                eventChannel.OnEventRaised -= OnEventRaised;
            }
        }

        public void OnEventRaised(string value) {
            StartCoroutine(RaiseEventDelayed(delay, value));
        }

        private IEnumerator RaiseEventDelayed(float delay, string value) {
            yield return new WaitForSeconds(delay);
            response.Invoke(value);
        }
    }
}
