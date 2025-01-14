using UnityEngine;
using System.Collections;

public class VisibilityEventTrigger : MonoBehaviour
{
    private bool hasTriggeredEvent = false;
    public GameObject targetObject; // Inspector����ړ����������I�u�W�F�N�g��ݒ肵�܂��B

    void Update()
    {
        // ���ׂĂ̎q�I�u�W�F�N�g���\������Ă��邩�`�F�b�N���A�C�x���g���܂��g���K�[����Ă��Ȃ��ꍇ�ɂ̂ݏ��������s
        if (!hasTriggeredEvent && AreAllChildrenVisible())
        {
            hasTriggeredEvent = true; // �C�x���g���g���K�[�������Ƃ��L�^���āA�ēx���s����Ȃ��悤�ɂ���
            StartCoroutine(MoveTargetObject(targetObject, new Vector3(0, -17.18f, 0), 10));
        }
    }

    bool AreAllChildrenVisible()
    {
        foreach (Transform child in transform)
        {
            if (!child.gameObject.activeSelf)
            {
                return false; // ��ł���\���̎q�I�u�W�F�N�g������΁Afalse��Ԃ�
            }
        }
        return true; // ���ׂĂ̎q�I�u�W�F�N�g���\������Ă���
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

        obj.transform.position = endPosition; // �m���ɖڕW�ʒu�ɐݒ�
    }
}
