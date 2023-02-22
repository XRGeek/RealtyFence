/* 
*   NatCorder
*   Copyright (c) 2020 Yusuf Olokoba
*/

namespace NatSuite.Examples
{

    using UnityEngine;
    using System.Collections;
    using Recorders;
    using Recorders.Clocks;
    using Recorders.Inputs;
    using NatSuite.Sharing;

    public class ReplayCam : MonoBehaviour
    {
        public GameObject canvas;



        [Header("Recording")]
        public int videoWidth = 1280;
        public int videoHeight = 720;
        public bool recordMicrophone;

        private IMediaRecorder recorder;
        private CameraInput cameraInput;
        private AudioInput audioInput;
        private AudioSource microphoneSource;

       

        public void StartRecording()
        {
            // Start recording
            var frameRate = 30;
            var sampleRate = recordMicrophone ? AudioSettings.outputSampleRate : 0;
            var channelCount = recordMicrophone ? (int)AudioSettings.speakerMode : 0;
            var clock = new RealtimeClock();
            recorder = new MP4Recorder(videoWidth, videoHeight, frameRate, sampleRate, channelCount);
            // Create recording inputs
            cameraInput = new CameraInput(recorder, clock, Camera.main);
            //audioInput = recordMicrophone ? new AudioInput(recorder, clock, microphoneSource, true) : null;
            // Unmute microphone
            //microphoneSource.mute = audioInput == null;
        }
        public async void StopRecording()
        {

            // Mute microphone
            //microphoneSource.mute = true;
            // Stop recording
            //audioInput?.Dispose();
            cameraInput.Dispose();
            var path = await recorder.FinishWriting();


            var sharepayload = new SharePayload();
            sharepayload.AddMedia(path);
            sharepayload.Commit();

        }


        public void TakeScreenShot()
        {
            Debug.Log("Screen Shot Taken");
            canvas.SetActive(false);
            StartCoroutine(TakeScreenshotAndSave());
        }
        private IEnumerator TakeScreenshotAndSave()
        {
            yield return new WaitForEndOfFrame();

            Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            ss.Apply();

            var sharepayload = new SharePayload();
            sharepayload.AddImage(ss);
            sharepayload.Commit();

            Destroy(ss);

            canvas.SetActive(true);
        }


    }
}