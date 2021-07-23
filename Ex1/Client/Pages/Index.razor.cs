using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex1.Client.Pages
{
    public partial class  Index
    {
        private MarkupString _reponses;
        private bool _IsDisabled = false;
        private string Nom = string.Empty;
        private Task DisplayInformations(string info)
        {
            _reponses = (MarkupString) (_reponses.Value+ $"<br> {info} ");
            if (info.Contains("FIN")) _IsDisabled = true;
            return Task.CompletedTask;
        }

       
    }
}
