using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Oculus.Interaction.Samples
{
    public class SceneLoader2 : MonoBehaviour
    {
        private bool _loading = false;
        private AsyncOperation _asyncLoad = null;
        public Action<string> WhenLoadingScene = delegate { };
        public Action<string> WhenSceneLoaded = delegate { };
        private int _waitingCount = 0;

        // �V�[���̃v�����[�h���J�n���郁�\�b�h
        public void PreloadScene(string sceneName)
        {
            if (_loading) return;
            _loading = true;
            StartCoroutine(PreloadSceneAsync(sceneName));
        }

        // �V�[���̔񓯊��v�����[�h
        private IEnumerator PreloadSceneAsync(string sceneName)
        {
            _asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            _asyncLoad.allowSceneActivation = false;  // �����I�ɃV�[�����A�N�e�B�u�ɂ��Ȃ�

            while (_asyncLoad.progress < 0.9f)
            {
                // ���[�h�i�s��...
                yield return null;
            }

            // ���[�h�������������A�܂��V�[���̓A�N�e�B�u�ɂ��Ȃ�
            _loading = false;
            WhenLoadingScene.Invoke(sceneName);
        }

        // �V�[�����A�N�e�B�u�ɂ��Đ؂�ւ���
        public void ActivateScene()
        {
            if (_asyncLoad != null && !_asyncLoad.isDone)
            {
                // ���[�h������ɃV�[�����A�N�e�B�u�ɂ���
                _asyncLoad.allowSceneActivation = true;
            }
        }

        // �ȑO�̃R�[�h�� Load ���\�b�h��u�������邽�߂Ɏg�p
        public void Load(string sceneName)
        {
            if (_loading) return;
            _loading = true;
            _waitingCount = WhenLoadingScene.GetInvocationList().Length - 1;  // remove the count for the blank delegate
            if (_waitingCount == 0)
            {
                PreloadScene(sceneName);
            }
            else
            {
                WhenLoadingScene.Invoke(sceneName);
            }
        }

        // HandleReadyToLoad �́APreloadSceneAsync �ő�ւ���܂����A�v�����[�h��̏������J�X�^�}�C�Y���邽�߂Ɏc���Ă������Ƃ��ł��܂��B
    }
}
