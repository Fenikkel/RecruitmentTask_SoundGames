using UnityEngine;

[CreateAssetMenu(fileName = "BoolVariable", menuName = "ScriptableObject Variables/Bool")]
public class BoolVariable : GenericVariable<bool>
{
    public void SetValue(BoolVariable value)
    {
        Value = value.Value;
    }
}
