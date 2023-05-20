StriX Interactive Event Channels
===============================

The StriX Interactive Event Channel system provides a way to manage and communicate events in Unity games. It consists of several scripts that offer the following functionalities:

*   `GenericEventChannelSO<T>`: An abstract class that serves as the base for specific event channel scripts. It allows creating and triggering events with a parameter of type `T`.

Supported Types
---------------

The StriX Interactive Event Channel system supports various types of events. You can create an event channel for any of the following types:

*   `float`: A floating-point value.
*   `string`: A text string.
*   `int`: An integer.
*   `bool`: A boolean value.
*   `GameObject`: A Unity GameObject.
*   `Vector2`: A 2D vector.
*   `Vector3`: A 3D vector.

Usage
-----

To use the StriX Interactive Event Channel system in your Unity project, follow these steps:

1.  Add the scripts to your Unity project.
2.  Create a class that inherits from `GenericEventChannelSO<T>` to define an event channel for your desired type. Use the `RaiseEvent` method to trigger an event with the corresponding parameter.
3.  Create an instance of the event channel class and keep a reference to it.
4.  Call the `RaiseEvent` method on the event channel instance to trigger the event.
5.  Define reactions to the event by creating relevant functions or methods and linking them to the desired GameObjects or components.

Here's an example of using the event channel system with the `int` type:

```csharp
using UnityEngine;
using UnityEditor;
using StriXInteractive.Tools.EventChannels;

public class MyEventChannel : GenericEventChannelSO<int>
{
    // Additional functions or properties can be defined here
}

[CustomEditor(typeof(MyEventChannel))]
public class MyEventChannelEditor : GenericEventChannelSOEditor<int>
{
    // Additional custom editor logic specific to MyEventChannel can be implemented here
}

public class MyEventSender : MonoBehaviour
{
    [SerializeField] private MyEventChannel eventChannel;

    private void Start()
    {
        // Example of triggering an event with an integer
        int myNumber = 42;
        eventChannel.RaiseEvent(myNumber);
    }
}
```

In the above example, the `GenericEventChannelSO<T>` class is used to define an event channel for events of type `int`. The `MyEventSender` script demonstrates how to use the `eventChannel` object to trigger the event with an integer value.

Note that you need to create your own class that inherits from `GenericEventChannelSO<T>` to define the event channel for your specific type. You can add additional functions or properties to this class to tailor it to your requirements.
