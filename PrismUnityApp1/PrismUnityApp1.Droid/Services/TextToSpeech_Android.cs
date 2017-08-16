using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Speech.Tts;
using Xamarin.Forms;
using System.Diagnostics;
using PrismUnityApp1.Interfaces;
using PrismUnityApp1.Droid.Services;

[assembly: Dependency(typeof(TextToSpeech_Android))]
namespace PrismUnityApp1.Droid.Services
{
    public class TextToSpeech_Android : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech speaker;
        private string toSpeak;

        public void Speak(string text)
        {
            var c = Forms.Context;
            toSpeak = text;

            if (speaker == null)
            {
                speaker = new TextToSpeech(c, this);
            }
            else
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
                Debug.WriteLine("spoke " + toSpeak);
            }
        }

        #region IOnInitListener implementation

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                Debug.WriteLine("speaker init");
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
            else
            {
                Debug.WriteLine("was quiet");
            }
        }

        #endregion

    }
}