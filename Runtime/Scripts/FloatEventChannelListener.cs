using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace StriXInteractive.Tools.EventChannels {
    public class FloatEventChannelListener : MonoBehaviour {

        [SerializeField] private FloatEventChannelSO eventChannel;
        [SerializeField] private UnityEvent<float> response;
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

        public void OnEventRaised(float value) {
            StartCoroutine(RaiseEventDelayed(delay, value));
        }

        private IEnumerator RaiseEventDelayed(float delay, float value) {
            yield return new WaitForSeconds(delay);
            response.Invoke(value);
        }
    }
}
