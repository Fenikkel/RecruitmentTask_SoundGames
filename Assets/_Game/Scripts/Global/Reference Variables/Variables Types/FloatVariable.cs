using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "ScriptableObject Variables/Float")]
public class FloatVariable : GenericVariable<float>
{
    public void SetValue(FloatVariable value)
    {
        Value = value.Value;
    }

    public void ApplyChange(float amount)
    {
        Value += amount;
    }

    public void ApplyChange(FloatVariable amount)
    {
        Value += amount.Value;
    }
}
