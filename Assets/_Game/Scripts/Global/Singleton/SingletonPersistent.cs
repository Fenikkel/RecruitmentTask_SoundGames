using UnityEngine;

public abstract class SingletonPersistent<T> : Singleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        CheckSingleton();
    }

    public override bool CheckSingleton()
    {
        bool isOriginal = base.CheckSingleton();

        if (isOriginal)
        {
            int numAttachedComponents = gameObject.GetComponents<Component>().Length;

            if (2 < numAttachedComponents)
            {
                Debug.LogWarning($"The persistent singleton <b>{name}</b> have <b>{numAttachedComponents - 2}</b> extra components appart of the Transform and himself. This extra components may be rubish in other scenes.");
            }

            this.transform.parent = null;   // Unparent for the sake of the DontDestroyOnLoad
            DontDestroyOnLoad(gameObject);
        }

        return isOriginal;
    }
}