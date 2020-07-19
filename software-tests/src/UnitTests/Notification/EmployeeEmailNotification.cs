using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Lib.Notification
{
    public class EmployeeEmailNotification : INotification
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }

        public EmployeeEmailNotification(string from, string to, string subject, string message)
        {
            From = from;
            To = to;
            Subject = subject;
            Message = message;
        }
    }
}
