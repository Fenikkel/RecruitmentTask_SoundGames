using UnityEngine;

[CreateAssetMenu(fileName = "IntVariable", menuName = "ScriptableObject Variables/Int")]
public class IntVariable : GenericVariable<int>
{
    public void SetValue(IntVariable value)
    {
        Value = value.Value;
    }

    public void ApplyChange(int amount)
    {
        Value += amount;
    }

    public void ApplyChange(IntVariable amount)
    {
        Value += amount.Value;
    }
}
