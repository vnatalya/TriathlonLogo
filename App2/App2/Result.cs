using System;
using System.Collections.Generic;
using System.Text;

namespace App2
{
    class Result
    {
        private string errorMessage;
        public string ErrorMessage { get { return errorMessage; } set { errorMessage = value; } }

        private string title;
        public string Title { get { return title; } set { title = value; } }

        private bool status;
        public bool Status { get { return status; } set { status = value; } }

        public Result(bool status, string title, string message) { 
            this.status = status;
            this.title = title;
            this.errorMessage = message;
        }

    }
}
