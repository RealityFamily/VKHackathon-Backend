using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKHackathon.WebApp.Services.Interfaces;

namespace VKHackathon.WebApp.Services
{
    public class CodeGeneratorService : ICodeGenerator
    {
        private Random random = new Random(DateTime.Now.Millisecond);

        public readonly Dictionary<Guid, int> OrderCodeDic = new Dictionary<Guid, int>();

        public int Code { get; private set; }
        public int CodeGenerate(Guid orderId)
        {
            Code = random.Next(0, 9999);
            OrderCodeDic.Add(orderId, Code);
            return Code;
        }
    }
}
