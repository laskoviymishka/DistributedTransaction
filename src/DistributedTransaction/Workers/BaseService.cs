using System;
using System.IO;
using DistributedTransaction.Exceptions;

namespace DistributedTransaction.Workers
{
    public abstract class BaseService
    {
        public string SuccessName { get; }
        public string FailName { get; }

        protected BaseService(string fileName, string failedName)
        {
            SuccessName = fileName;
            FailName = failedName;
            File.Delete(SuccessName);
            File.Delete(FailName);
        }

        public void RunSingle(int iterationIndex)
        {
            var randomValue = new Random().Next(0, 5);
            if (randomValue == 3)
            {
                File.AppendAllLines(FailName, new[] { iterationIndex.ToString() });
                throw new SingleWorkerException(iterationIndex, this.GetType().FullName);
            }

            File.AppendAllLines(SuccessName, new[] { iterationIndex.ToString() });
        }
    }
}