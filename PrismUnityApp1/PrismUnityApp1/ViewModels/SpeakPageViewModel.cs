using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUnityApp1.ViewModels
{
    public class SpeakPageViewModel : BindableBase
    {
        private string _txtToSay = "Hola Camaradas";
        public string TextToSay
        {
            get { return _txtToSay; }
            set { SetProperty(ref _txtToSay, value); }
        }
        public DelegateCommand SpeakCommand { get; set; }
        public SpeakPageViewModel()
        {
            SpeakCommand = new DelegateCommand(Speak);

        }
        private void Speak()
        {
            //TODO: speak
        }
    }
}
