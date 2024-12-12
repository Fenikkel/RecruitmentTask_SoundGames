using UnityEngine;

[CreateAssetMenu(fileName = "StringVariable", menuName = "ScriptableObject Variables/String")]
public class StringVariable : GenericVariable<string>
{
    public void SetValue(StringVariable value)
    {
        Value = value.Value;
    }
}
