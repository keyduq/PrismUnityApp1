using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using PrismUnityApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUnityApp1.ViewModels
{
    public class SpeakPageViewModel : BindableBase
    {
        private readonly ITextToSpeech _textToSpeech;
        private string _txtToSay = "Hola Camaradas";
        public DelegateCommand SpeakCommand { get; set; }
        private IPageDialogService _dialogService;
        public string TextToSay
        {
            get { return _txtToSay; }
            set { SetProperty(ref _txtToSay, value); }
        }

        public SpeakPageViewModel(IPageDialogService dialogService, ITextToSpeech textToSpeech)
        {
            SpeakCommand = new DelegateCommand(Speak);
            _dialogService = dialogService;
            _textToSpeech = textToSpeech;
        }

        private void Speak()
        {
            _textToSpeech.Speak(TextToSay);
            _dialogService.DisplayAlertAsync("Speak", TextToSay, "OK");
        }
    }
}
