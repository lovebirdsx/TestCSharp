using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

// Argument: –flag 
// Usage: args.IsTrue("flag"); 
// Result: true 
// 
// Argument: –arg:MyValue 
// Usage: args.Single("arg"); 
// Result: MyValue 
// 
// Argument: –arg "My Value" 
// Usage: args.Single("arg"); 
// Result: ‘My Value’ 
// 
// Argument: /arg=Value /arg=Value2 
// Usage: args["arg"] 
// Result: new string[] {"Value", "Value2"} 
// 
// Argument: /arg="Value,Value2" 
// Usage: args["arg"] 
// Result: new string[] {"Value", "Value2"} 

/// <summary>
/// Arguments class
/// </summary>
public class CommandArgs {
    /// <summary>
    /// Splits the command line. When main(string[] args) is used escaped quotes (ie a path "c:\folder\")
    /// Will consume all the following command line arguments as the one argument. 
    /// This function ignores escaped quotes making handling paths much easier.
    /// </summary>
    /// <param name="commandLine">The command line.</param>
    /// <returns></returns>
    public static string[] SplitCommandLine(string commandLine) {
        var translatedArguments = new StringBuilder(commandLine);
        var escaped = false;
        for (var i = 0; i < translatedArguments.Length; i++) {
            if (translatedArguments[i] == '"') {
                escaped = !escaped;
            }
            if (translatedArguments[i] == ' ' && !escaped) {
                translatedArguments[i] = '\n';
            }
        }

        var toReturn = translatedArguments.ToString().Split(new [] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < toReturn.Length; i++) {
            toReturn[i] = RemoveMatchingQuotes(toReturn[i]);
        }
        return toReturn;
    }

    public static string RemoveMatchingQuotes(string stringToTrim) {
        var firstQuoteIndex = stringToTrim.IndexOf('"');
        var lastQuoteIndex = stringToTrim.LastIndexOf('"');
        while (firstQuoteIndex != lastQuoteIndex) {
            stringToTrim = stringToTrim.Remove(firstQuoteIndex, 1);
            stringToTrim = stringToTrim.Remove(lastQuoteIndex - 1, 1); //-1 because we've shifted the indicies left by one
            firstQuoteIndex = stringToTrim.IndexOf('"');
            lastQuoteIndex = stringToTrim.LastIndexOf('"');
        }

        return stringToTrim;
    }

    private readonly Dictionary<string, Collection<string>> _parameters;
    private string _waitingParameter;

    public CommandArgs(IEnumerable<string> arguments) {
        _parameters = new Dictionary<string, Collection<string>>();

        string[] parts;

        //Splits on beginning of arguments ( - and -- and / )
        //And on assignment operators ( = and : )
        var argumentSplitter = new Regex(@"^-{1,2}|=",
            // RegexOptions.IgnoreCase | RegexOptions.Compiled);
            RegexOptions.IgnoreCase);

        foreach (var argument in arguments) {
            parts = argumentSplitter.Split(argument, 3);
            switch (parts.Length) {
                case 1:
                    AddValueToWaitingArgument(parts[0]);
                    break;
                case 2:
                    AddWaitingArgumentAsFlag();

                    //Because of the split index 0 will be a empty string
                    _waitingParameter = parts[1];
                    break;
                case 3:
                    AddWaitingArgumentAsFlag();

                    //Because of the split index 0 will be a empty string
                    string valuesWithoutQuotes = RemoveMatchingQuotes(parts[2]);

                    AddListValues(parts[1], valuesWithoutQuotes.Split(','));
                    break;
            }
        }

        AddWaitingArgumentAsFlag();
    }

    private void AddListValues(string argument, IEnumerable<string> values) {
        foreach (var listValue in values) {
            Add(argument, listValue);
        }
    }

    private void AddWaitingArgumentAsFlag() {
        if (_waitingParameter == null) return;

        AddSingle(_waitingParameter, "true");
        _waitingParameter = null;
    }

    private void AddValueToWaitingArgument(string value) {
        if (_waitingParameter == null) return;

        value = RemoveMatchingQuotes(value);

        Add(_waitingParameter, value);
        _waitingParameter = null;
    }

    /// <summary>
    /// Gets the count.
    /// </summary>
    /// <value>The count.</value>
    public int Count {
        get {
            return _parameters.Count;
        }
    }

    /// <summary>
    /// Adds the specified argument.
    /// </summary>
    /// <param name="argument">The argument.</param>
    /// <param name="value">The value.</param>
    public void Add(string argument, string value) {
        if (!_parameters.ContainsKey(argument))
            _parameters.Add(argument, new Collection<string>());
        
        _parameters[argument].Add(value);
    }

    public void AddSingle(string argument, string value) {
        if (!_parameters.ContainsKey(argument))
            _parameters.Add(argument, new Collection<string>());
        else
            throw new ArgumentException(string.Format("Argument {0} has already been defined", argument));

        _parameters[argument].Add(value);
    }

    public void Remove(string argument) {
        if (_parameters.ContainsKey(argument))
            _parameters.Remove(argument);
    }

    /// <summary>
    /// Determines whether the specified argument is true.
    /// </summary>
    /// <param name="argument">The argument.</param>
    /// <returns>
    ///     <c>true</c> if the specified argument is true; otherwise, <c>false</c>.
    /// </returns>
    public bool IsTrue(string argument) {
        AssertSingle(argument);

        var arg = this[argument];

        return arg != null && arg[0].Equals("true", StringComparison.OrdinalIgnoreCase);
    }

    private void AssertSingle(string argument) {
        if (this[argument] != null && this[argument].Count > 1)
            throw new ArgumentException(string.Format("{0} has been specified more than once, expecting single value", argument));
    }

    public string Single(string argument) {
        AssertSingle(argument);

        //only return value if its NOT true, there is only a single item for that argument
        //and the argument is defined
        if (this[argument] != null && !IsTrue(argument))
            return this[argument][0];

        return null;
    }

    public bool Exists(string argument) {
        return (this[argument] != null && this[argument].Count > 0);
    }

    public IEnumerable<string> GetArgNames() {
        return _parameters.Keys;
    }

    /// <summary>
    /// Gets the <see cref="System.Collections.ObjectModel.Collection&lt;T&gt;"/> with the specified parameter.
    /// </summary>
    /// <value></value>
    public Collection<string> this[string parameter] {
        get {
            return _parameters.ContainsKey(parameter) ? _parameters[parameter] : null;
        }
    }
}

string[] args = {
    "-path",
    "C:\\hello.exe",
    "-locationPathName",
    "/Users/ejoy/git_project/pubg/pubg_xcode",
    "-fuck",
};

CommandArgs cmdArgs = new CommandArgs(args);
var argNames = cmdArgs.GetArgNames();
foreach (var arg in argNames) {
    var value = cmdArgs[arg][0];
    Console.WriteLine("{0} = {1}", arg, value);
}
