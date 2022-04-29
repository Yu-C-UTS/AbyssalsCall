using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

public class StringSystemConverter : MonoBehaviour
{
    [System.Serializable]
    public class StringSystemDictionary : SerializableDictionaryBase<string, SystemBase> {}

    public static StringSystemConverter Instance
    {
        get
        {
            return _Instance;
        }
    }
    private static StringSystemConverter _Instance;

    [SerializeField]
    private StringSystemDictionary StringSystemDict;

    private void Awake() 
    {
        if(_Instance != null)
        {
            Debug.LogWarning("Another String System Converter already exist, destroying new one.");
            Destroy(this);
            return;
        }   
        _Instance = this;
    }

    public SystemBase StringToSystem(string str)
    {
        if(StringSystemDict.ContainsKey(str))
        {
            return StringSystemDict[str];
        }
        Debug.LogError("No system found for string: " + str);
        return null;
    }
}
