using System;
using System.Diagnostics.Contracts;

namespace MLC.Eps
{
    [ContractClass(typeof (MacroProcessorContract))]
    public interface IMacroProcessor
    {
        string Process(string source);

        void Add(string key, string value);
        void Add(string key, Func<string, string> valueAction);
        void AddOrReplace(string key, Func<string, string> valueAction);

        IMacroProcessor GetChildProcessor();
    }

    [ContractClassFor(typeof (IMacroProcessor))]
    abstract class MacroProcessorContract : IMacroProcessor
    {
        string IMacroProcessor.Process(string source)
        {
            Contract.Requires(!string.IsNullOrEmpty(source));

            throw new NotImplementedException();
        }

        void IMacroProcessor.Add(string key, string value)
        {
            Contract.Requires(!string.IsNullOrEmpty(key));

            throw new NotImplementedException();
        }

        public void Add(string key, Func<string, string> valueAction)
        {
            Contract.Requires(!string.IsNullOrEmpty(key));
            Contract.Requires(valueAction != null);

            throw new NotImplementedException();
        }

        public void AddOrReplace(string key, Func<string, string> valueAction)
        {
            Contract.Requires(!string.IsNullOrEmpty(key));
            Contract.Requires(valueAction != null);

            throw new NotImplementedException();
        }

        public IMacroProcessor GetChildProcessor()
        {
            throw new NotImplementedException();
        }
    }
}