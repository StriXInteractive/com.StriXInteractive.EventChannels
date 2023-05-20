using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace StriXInteractive.Tools.EventChannels {
    public class Vector2EventChannelListener : MonoBehaviour {

        [SerializeField] private Vector2EventChannelSO eventChannel;
        [SerializeField] private UnityEvent<Vector2> response;
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

        public void OnEventRaised(Vector2 value) {
            StartCoroutine(RaiseEventDelayed(delay, value));
        }

        private IEnumerator RaiseEventDelayed(float delay, Vector2 value) {
            yield return new WaitForSeconds(delay);
            response.Invoke(value);
        }
    }
}
