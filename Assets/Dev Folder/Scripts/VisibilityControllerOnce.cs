using UnityEngine;

public class VisibilityControllerOnce : MonoBehaviour
{
    public GameObject[] objectsToHide; // 非表示にするオブジェクト群
    public GameObject objectToShow; // 表示状態にするオブジェクト
    private bool hasShown = false; // オブジェクトを表示したかどうかのフラグ

    void Update()
    {
        if (!hasShown && AreAllObjectsHidden())
        {
            objectToShow.SetActive(true); // オブジェクトを表示
            hasShown = true; // 表示フラグをtrueに設定
            this.enabled = false; // このスクリプトを無効化し、これ以上Updateが呼ばれないようにする
        }
    }

    bool AreAllObjectsHidden()
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (obj.activeSelf)
            {
                return false; // 一つでも表示されているオブジェクトがあればfalseを返す
            }
        }
        return true; // すべてのオブジェクトが非表示ならtrueを返す
    }
}
