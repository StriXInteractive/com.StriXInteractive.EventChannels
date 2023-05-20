using UnityEngine;
using UnityEngine.Events;

namespace StriXInteractive.Tools.EventChannels {

    [CreateAssetMenu(fileName = "VoidEventChannelSO", menuName = "StriXInteractive/Events/VoidEventChannelSO")]
    public class VoidEventChannelSO : ScriptableObject {
        public UnityAction OnEventRaised;

        public void RaiseEvent() {
            if (OnEventRaised != null) {
                OnEventRaised.Invoke();
            }
        }
    }

}
