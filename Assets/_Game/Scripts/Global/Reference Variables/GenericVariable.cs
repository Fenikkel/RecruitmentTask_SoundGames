// Generic
using UnityEngine;

public class GenericVariable<T> : ScriptableObject
{
#if UNITY_EDITOR
    //[Multiline]
    [TextArea(minLines: 3, maxLines: 10)]
#pragma warning disable CS0414
    [SerializeField] string Info = "";
#pragma warning restore CS0414
#endif
    [Space]

    public T Value;

    public virtual void SetValue(T value)
    {
        Value = value;
    }
}