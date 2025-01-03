using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Presentation.Helpers
{
    public static class CommandParser
    {
        public static bool TryParseCommand(string command, string prefix, out string parameter)
        {
            parameter = string.Empty;

            if (string.IsNullOrWhiteSpace(command) || !command.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            parameter = command.Substring(prefix.Length).Trim();
            return !string.IsNullOrWhiteSpace(parameter);
        }
    }
}
