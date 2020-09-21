using System;
using System.Collections.Generic;
using System.Text;

namespace AccessUniversity.Models
{
    class AssessmentData
    {
        private string assessmentNumber;
        private string assessmentTitle;
        private string assessmentContent;

        public string AssessmentNumber { get => assessmentNumber; set => assessmentNumber = value; }
        public string AssessmentTitle { get => assessmentTitle; set => assessmentTitle = value; }
        public string AssessmentContent { get => assessmentContent; set => assessmentContent = value; }
    }
}
