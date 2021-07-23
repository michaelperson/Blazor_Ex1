using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex1.Client.Components.Quizz
{
    public class QuizzBase: ComponentBase
    {
        private int pos = 1;
        protected string infoPos;
        string _user;
        readonly List<string> Questions;

        [Parameter]
        public string User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
            }
        }
        [Parameter]
        public bool IsDisabled
        {
            get;set;
        }

        [Parameter]
        public EventCallback<string> onAnswer { get; set; }
        
        protected string currentQuestion;

        public QuizzBase()
        {
            Questions = new List<string>() { 
                "Blazor permet-il de faire du SPA?", 
                "Un EventCallBack<T> fonctionne comme un .net event?",
                "L'exercice est-il bien compris?"};
            currentQuestion = Questions[0];
            infoPos="voici la question n° " + pos;
        }

        public async Task Answer(string rep)
        {
            await onAnswer.InvokeAsync(rep);
            pos++;
            infoPos = "voici la question n° " + pos;
            if (pos > Questions.Count)
            {
                await onAnswer.InvokeAsync($"FIN DU QUIZZ");
                currentQuestion = "";
                infoPos = " Vous avez terminé!";
            }
            else
            {

                currentQuestion = Questions[pos - 1];
                
            }
        }



    }
}
