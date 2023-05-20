using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace StriXInteractive.Tools.EventChannels {
    public class BoolEventChannelListener : MonoBehaviour {

        [SerializeField] private BoolEventChannelSO eventChannel;
        [SerializeField] private UnityEvent<bool> response;
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

        public void OnEventRaised(bool value) {
            StartCoroutine(RaiseEventDelayed(delay, value));
        }

        private IEnumerator RaiseEventDelayed(float delay, bool value) {
            yield return new WaitForSeconds(delay);
            response.Invoke(value);
        }
    }
}
