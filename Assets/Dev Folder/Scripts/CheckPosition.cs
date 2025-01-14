using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    public ObjectListManager _manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Debug.Log(_manager._listObject.Find(x => x._name == "ç≈èâ")._transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
