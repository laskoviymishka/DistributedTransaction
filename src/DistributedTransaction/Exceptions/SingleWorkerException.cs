using System;

namespace DistributedTransaction.Exceptions
{
    public class SingleWorkerException : Exception
    {
        public int IterationIndex { get; }
        public string Name { get; }

        public SingleWorkerException(int iterationIndex, string name) : base("")
        {
            Name = name;
            IterationIndex = iterationIndex;
        }

        public override string ToString() => $"{Name} - {IterationIndex}";
    }
}