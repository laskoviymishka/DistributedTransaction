using System;
using System.Collections.Generic;
using System.IO;
using DistributedTransaction.Exceptions;
using DistributedTransaction.Workers;

namespace DistributedTransaction
{
    public class Service
    {
        public ServiceResult Run(int count)
        {
            File.Delete("./_success.log");
            File.Delete("./_fail.log");
            var first = new FirstService();
            var second = new SecondService();
            var third = new ThirdService();

            for (int i = 0; i < count; i++)
            {
                try
                {
                    first.RunSingle(i);
                    second.RunSingle(i);
                    third.RunSingle(i);

                    File.AppendAllLines("./_success.log", new[] { i.ToString() });
                }
                catch (SingleWorkerException exception)
                {
                    File.AppendAllLines("./_fail.log", new[] { exception.ToString() });
                }
            }

            return new ServiceResult
            {
                TotalSuccess = File.ReadAllLines("./_success.log"),
                TotalFail = File.Exists("./_fail.log") ? File.ReadAllLines("./_fail.log") : new string[] {},
                ChildSuccess = new List<IList<string>>
                {
                    File.ReadAllLines(first.SuccessName),
                    File.ReadAllLines(second.SuccessName),
                    File.ReadAllLines(third.SuccessName)
                }
            };
        }
    }
}