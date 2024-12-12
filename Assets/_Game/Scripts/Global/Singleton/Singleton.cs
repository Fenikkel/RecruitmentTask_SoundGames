using UnityEngine;

// TODO: Check the most derived type : var derivedType = typeof(T);

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        CheckSingleton();
    }

    public virtual bool CheckSingleton()
    {
        // Check if base and derived classes are the same type
        if (this is not T)
        {
            Debug.LogError($"Base and derived classes are different types:\n\t- Base: {typeof(T)}\n\t- Derived: {GetType()}\nPlease modify {typeof(T)}\nDestroying the component in <b>{name}</b>.");
            Destroy(this);
            return false;
        }

        // Check if this instance is a duplicated
        if (Instance != null && Instance != this)
        {   
            if (this.gameObject.GetComponents<Component>().Length <= 2)
            {
                Debug.LogWarning($"Multiple instances of <b>{GetType().Name}</b>\nDestroying the gameobject <b>{name}</b>.");
                Destroy(this.gameObject);
            }
            else
            {
                Debug.LogWarning($"Multiple instances of <b>{GetType().Name}</b>\nDestroying the component in <b>{name}</b>.");
                DestroyImmediate(this); // Instant destruction to avoid waiting for the end of the frame.
            }
            return false;
        }

        // Set this instance as the selected
        Instance = this as T;
        return true;
    }
}