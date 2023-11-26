using System;
using System.Collections.Generic;
using System.Text;
using WebApiHumanModels.Enums;

namespace WebApiHumanModels.ViewModels.BasicOperation
{
    public class BasicOperationViewModel
    {
        public double num1 { get; set; }
        public double num2 { get; set; }
        public BasicOperations BasicOperation { get; set; }
    }
}
