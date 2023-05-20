using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace StriXInteractive.Tools.EventChannels {
    public class VoidEventChannelListener : MonoBehaviour {

        [SerializeField] private VoidEventChannelSO eventChannel;
        [SerializeField] private UnityEvent response;
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

        public void OnEventRaised() {
            StartCoroutine(RaiseEventDelayed(delay));
        }

        private IEnumerator RaiseEventDelayed(float delay) {
            yield return new WaitForSeconds(delay);
            response.Invoke();
        }
    }
}
