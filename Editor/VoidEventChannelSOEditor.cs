using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace StriXInteractive.Tools.EventChannels {
    [CustomEditor(typeof(VoidEventChannelSO), true)]
    public class VoidEventChannelSOEditor : Editor {

        private VoidEventChannelSO eventChannel;

        private void OnEnable() {
            if (eventChannel == null) {
                eventChannel = target as VoidEventChannelSO;
            }
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Listeners:", EditorStyles.boldLabel);

            ShowListenersListView();

            EditorGUILayout.Space();

            if (GUILayout.Button("Raise Event")) {
                eventChannel.RaiseEvent();
            }
        }

        private void ShowListenersListView() {
            List<MonoBehaviour> listeners = GetListeners();

            foreach (var listener in listeners) {
                if (listener == null)
                    continue;

                string combinedName = listener.gameObject.name + " (" + listener.GetType().Name + ")";
                EditorGUILayout.LabelField(combinedName);

                if (GUILayout.Button("Ping")) {
                    EditorGUIUtility.PingObject(listener.gameObject);
                }
            }
        }

        private List<MonoBehaviour> GetListeners() {
            List<MonoBehaviour> listeners = new List<MonoBehaviour>();

            if (eventChannel == null || eventChannel.OnEventRaised == null) {
                return listeners;
            }

            var delegateSubscribers = eventChannel.OnEventRaised.GetInvocationList();
            foreach (var subscriber in delegateSubscribers) {

                var componentListener = subscriber.Target as MonoBehaviour;
                if (!listeners.Contains(componentListener)) {
                    listeners.Add(componentListener);
                }
            }

            return listeners;
        }
    }
}
