using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PresentationLayer.Models
{
    public class ConfirmMailViewModel
    {
        public int Id { get; set; }
        public int ConfirmCode { get; set; }
    }
}