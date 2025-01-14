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

        // シーンのプリロードを開始するメソッド
        public void PreloadScene(string sceneName)
        {
            if (_loading) return;
            _loading = true;
            StartCoroutine(PreloadSceneAsync(sceneName));
        }

        // シーンの非同期プリロード
        private IEnumerator PreloadSceneAsync(string sceneName)
        {
            _asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            _asyncLoad.allowSceneActivation = false;  // 自動的にシーンをアクティブにしない

            while (_asyncLoad.progress < 0.9f)
            {
                // ロード進行中...
                yield return null;
            }

            // ロードが完了したが、まだシーンはアクティブにしない
            _loading = false;
            WhenLoadingScene.Invoke(sceneName);
        }

        // シーンをアクティブにして切り替える
        public void ActivateScene()
        {
            if (_asyncLoad != null && !_asyncLoad.isDone)
            {
                // ロード完了後にシーンをアクティブにする
                _asyncLoad.allowSceneActivation = true;
            }
        }

        // 以前のコードの Load メソッドを置き換えるために使用
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

        // HandleReadyToLoad は、PreloadSceneAsync で代替されますが、プリロード後の処理をカスタマイズするために残しておくこともできます。
    }
}
