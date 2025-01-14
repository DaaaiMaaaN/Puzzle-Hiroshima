using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectListManager : MonoBehaviour
{
    [SerializeField, Tooltip("�I�u�W�F�N�g���X�g")]
    public List<ScenarioObject> _listObject;

    [System.Serializable]
    public class ScenarioObject
    {
        public string _name;
        public GameObject _gameObject;

        //�R���|�[�l���g��o�^���Ă���
        [System.NonSerialized] public Transform _transform;

        public void Init()
        {
            //�������ɃR���|�[�l���g���擾
            _transform = _gameObject.GetComponent<Transform>();
        }
    }
    public void Awake()
    {
        //�������ɃR���|�[�l���g���擾
        foreach (var v in _listObject) v.Init();
    }

}
