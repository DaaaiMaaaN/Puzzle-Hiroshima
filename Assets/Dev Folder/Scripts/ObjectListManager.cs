using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectListManager : MonoBehaviour
{
    [SerializeField, Tooltip("オブジェクトリスト")]
    public List<ScenarioObject> _listObject;

    [System.Serializable]
    public class ScenarioObject
    {
        public string _name;
        public GameObject _gameObject;

        //コンポーネントを登録しておく
        [System.NonSerialized] public Transform _transform;

        public void Init()
        {
            //生成時にコンポーネントを取得
            _transform = _gameObject.GetComponent<Transform>();
        }
    }
    public void Awake()
    {
        //生成時にコンポーネントを取得
        foreach (var v in _listObject) v.Init();
    }

}
