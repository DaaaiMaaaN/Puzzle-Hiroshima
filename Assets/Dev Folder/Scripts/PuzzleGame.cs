using UnityEngine;
public class PuzzleGame : MonoBehaviour
{
    public Transform objectA; // �I�u�W�F�N�gA
    public AudioSource audioSource; // �Đ����鉹��
    public float closeDistance = 0.1f; // ����������
    public float correctAngle = 10.0f; // �p�x
    private bool isObjectBClose = false;
    private bool isCorrectAngle = false;
    void Start()
    {
        objectA.gameObject.SetActive(false); // A�͔�\������X�^�[�g
        gameObject.SetActive(true);  // B�͕\����ԂŃX�^�[�g�i���̃X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g�j
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
        gameObject.SetActive(false); // B�i���̃X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g�j���\����
        objectA.gameObject.SetActive(true);  // A��\����
        audioSource.Play(); // �������Đ�
    }
}