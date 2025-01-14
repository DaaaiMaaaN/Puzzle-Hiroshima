using UnityEngine;
using System.Collections;

public class VisibilityEventTrigger : MonoBehaviour
{
    private bool hasTriggeredEvent = false;
    public GameObject targetObject; // Inspectorから移動させたいオブジェクトを設定します。

    void Update()
    {
        // すべての子オブジェクトが表示されているかチェックし、イベントがまだトリガーされていない場合にのみ処理を実行
        if (!hasTriggeredEvent && AreAllChildrenVisible())
        {
            hasTriggeredEvent = true; // イベントをトリガーしたことを記録して、再度実行されないようにする
            StartCoroutine(MoveTargetObject(targetObject, new Vector3(0, -17.18f, 0), 10));
        }
    }

    bool AreAllChildrenVisible()
    {
        foreach (Transform child in transform)
        {
            if (!child.gameObject.activeSelf)
            {
                return false; // 一つでも非表示の子オブジェクトがあれば、falseを返す
            }
        }
        return true; // すべての子オブジェクトが表示されている
    }

    IEnumerator MoveTargetObject(GameObject obj, Vector3 moveBy, float duration)
    {
        Vector3 startPosition = obj.transform.position;
        Vector3 endPosition = startPosition + moveBy;
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            obj.transform.position = Vector3.Lerp(startPosition, endPosition, (Time.time - startTime) / duration);
            yield return null;
        }

        obj.transform.position = endPosition; // 確実に目標位置に設定
    }
}
