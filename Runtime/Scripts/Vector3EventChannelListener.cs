using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace StriXInteractive.Tools.EventChannels {
    public class Vector3EventChannelListener : MonoBehaviour {

        [SerializeField] private Vector3EventChannelSO eventChannel;
        [SerializeField] private UnityEvent<Vector3> response;
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

        public void OnEventRaised(Vector3 value) {
            StartCoroutine(RaiseEventDelayed(delay, value));
        }

        private IEnumerator RaiseEventDelayed(float delay, Vector3 value) {
            yield return new WaitForSeconds(delay);
            response.Invoke(value);
        }
    }
}
