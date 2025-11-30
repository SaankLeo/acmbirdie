using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VidPlayercontroller : MonoBehaviour
{
    public VideoPlayer vidPlayer;

    private void Start()
    {
        vidPlayer.loopPointReached += OnVideoEnd;
        vidPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        StartCoroutine(LoadMainGame());
    }

    IEnumerator LoadMainGame()
    {
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene("MainGame");
    }
}
