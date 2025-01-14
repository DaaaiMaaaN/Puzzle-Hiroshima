using UnityEngine;
public class PuzzleGame : MonoBehaviour
{
    public Transform objectA; // オブジェクトA
    public AudioSource audioSource; // 再生する音声
    public float closeDistance = 0.1f; // くっつく距離
    public float correctAngle = 10.0f; // 角度
    private bool isObjectBClose = false;
    private bool isCorrectAngle = false;
    void Start()
    {
        objectA.gameObject.SetActive(false); // Aは非表示からスタート
        gameObject.SetActive(true);  // Bは表示状態でスタート（このスクリプトがアタッチされたオブジェクト）
    }
    void Update()
    {
        CheckAngle();
        if (isCorrectAngle)
        {
            Invoke("CheckDistance", 0.5f);
        }
        if (isObjectBClose && isCorrectAngle)
        {
            SwitchObjects();
        }
    }
    void CheckAngle()
    {
        float angle = Vector3.Angle(transform.up, objectA.up);
        if (angle <= correctAngle)
        {
            isCorrectAngle = true;
        }
        else
        {
            isCorrectAngle = false;
        }
    }
    void CheckDistance()
    {
        float distance = Vector3.Distance(transform.position, objectA.position);
        if (distance <= closeDistance)
        {
            isObjectBClose = true;
        }
        else
        {
            isObjectBClose = false;
        }
    }
    void SwitchObjects()
    {
        gameObject.SetActive(false); // B（このスクリプトがアタッチされたオブジェクト）を非表示に
        objectA.gameObject.SetActive(true);  // Aを表示に
        audioSource.Play(); // 音声を再生
    }
}