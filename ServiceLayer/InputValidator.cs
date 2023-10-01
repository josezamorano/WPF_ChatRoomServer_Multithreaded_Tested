﻿using ServiceLayer.Interfaces;

namespace ServiceLayer
{
    public class InputValidator : IInputValidator
    {

        public string ValidateServerInputs(string port)
        {
            var portReport = ResolvePortNumberForClients(port);
            return portReport;
        }


        #region Private Methods

        private string ResolvePortNumberForClients(string port)
        {
            int portNumber = 0;
            bool isValidNumber = int.TryParse(port, out portNumber);
            if (isValidNumber && portNumber >= 49152 && portNumber <= 65535)
            {
                return string.Empty;
            }

            return "Insert a port Number between 49152 and 65535";
        }
        #endregion 
    }
}
