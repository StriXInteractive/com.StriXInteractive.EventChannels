using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace StriXInteractive.Tools.EventChannels {
    public class GameObjectEventChannelListener : MonoBehaviour {

        [SerializeField] private GameObjectEventChannelSO eventChannel;
        [SerializeField] private UnityEvent<GameObject> response;
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

        public void OnEventRaised(GameObject value) {
            StartCoroutine(RaiseEventDelayed(delay, value));
        }

        private IEnumerator RaiseEventDelayed(float delay, GameObject value) {
            yield return new WaitForSeconds(delay);
            response.Invoke(value);
        }
    }
}
