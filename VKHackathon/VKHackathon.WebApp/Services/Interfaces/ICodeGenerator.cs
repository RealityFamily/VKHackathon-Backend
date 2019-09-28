using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VKHackathon.WebApp.Services.Interfaces
{
    public interface ICodeGenerator
    {
        int CodeGenerate(Guid orderId);
    }
}
