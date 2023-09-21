using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseasyCommon.Service
{
    public interface IApiToken
    {
        Task<string> Obter();
    }
}
