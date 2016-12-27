using System.Collections;
using System.Collections.Generic;

namespace DistributedTransaction
{
    public class ServiceResult
    {
        public IList<string> TotalSuccess { get; set; }
        public IList<string> TotalFail { get; set; }
        public IList<IList<string>> ChildSuccess { get; set; }
    }
}