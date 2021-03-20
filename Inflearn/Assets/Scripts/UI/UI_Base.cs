using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{


    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();


    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objects[i] = Util.FindChild(gameObject, names[i], true);
            }
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);

            if (objects[i] == null)
                print($"Failed to bind({names[i]})");
        }
    }

    T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        _objects.TryGetValue(typeof(T), out objects);
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[idx] as T;
    }

    protected Text GetText(int idx) { return Get<Text>(idx); }

    protected Button GetButton(int idx) { return Get<Button>(idx); }
}
