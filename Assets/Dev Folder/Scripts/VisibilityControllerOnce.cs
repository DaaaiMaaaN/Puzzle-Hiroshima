using UnityEngine;

public class VisibilityControllerOnce : MonoBehaviour
{
    public GameObject[] objectsToHide; // ��\���ɂ���I�u�W�F�N�g�Q
    public GameObject objectToShow; // �\����Ԃɂ���I�u�W�F�N�g
    private bool hasShown = false; // �I�u�W�F�N�g��\���������ǂ����̃t���O

    void Update()
    {
        if (!hasShown && AreAllObjectsHidden())
        {
            objectToShow.SetActive(true); // �I�u�W�F�N�g��\��
            hasShown = true; // �\���t���O��true�ɐݒ�
            this.enabled = false; // ���̃X�N���v�g�𖳌������A����ȏ�Update���Ă΂�Ȃ��悤�ɂ���
        }
    }

    bool AreAllObjectsHidden()
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (obj.activeSelf)
            {
                return false; // ��ł��\������Ă���I�u�W�F�N�g�������false��Ԃ�
            }
        }
        return true; // ���ׂẴI�u�W�F�N�g����\���Ȃ�true��Ԃ�
    }
}
