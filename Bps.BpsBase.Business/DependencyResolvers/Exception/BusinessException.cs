using System;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.Core.GlobalStaticsVariables;

namespace Bps.BpsBase.Business.DependencyResolvers.Exception
{
    [Serializable]
    public class BusinessException : System.Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message) : base(message)
        {
            this.Source = "BusinessException";
        }

        public BusinessException FromMessageNo(string messageNo, Global global, string m1=null, string m2=null, string m3=null, string m4 = null, string mesajKod = null)
        {
            IGnmesjService gnmesjService = InstanceFactory.GetInstance<IGnmesjService>();
            var data = gnmesjService.GetMesajDirect(global, messageNo, m1: m1, m2: m2, m3: m3, m4: m4, mesajKod ?? global.ProjeKod);
            return new BusinessException(data.Nesne.MSTEXT);
        }
    }
}