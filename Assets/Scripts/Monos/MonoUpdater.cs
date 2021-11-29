using System;
using System.Collections;
using UnityEngine;

public class MonoUpdater : MonoBehaviour
{
    public event Action Updated;
    public event Action FixedUpdated;
    public event Action LateUpdated;

    private void Update() { Updated?.Invoke(); }
    private void FixedUpdate() { FixedUpdated?.Invoke(); }
    private void LateUpdate() { LateUpdated?.Invoke(); }
}
