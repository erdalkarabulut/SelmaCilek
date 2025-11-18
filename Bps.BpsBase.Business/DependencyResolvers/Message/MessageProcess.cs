using Bps.BpsBase.DataAccess.Abstract.GN;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.GN;

namespace Bps.BpsBase.Business.DependencyResolvers.Message
{
    public static class MessageProcess
    {
        public static  string FromMessageNo(string messageKod, string messageNo, string langkd, string m1 = null, string m2 = null, string m3 = null, string m4 = null)
        {
            IGnmesjDal gnmesjDal = new EfGnmesjDal();
            var entity = gnmesjDal.Get(w => w.MESJKD == messageKod && w.MESJNO == messageNo && w.LANGKD == langkd);

            var message = entity.MSTEXT; // parse from json here

            if (!string.IsNullOrEmpty(m1)) message = message.Replace("{0}", m1);
            if (!string.IsNullOrEmpty(m2)) message = message.Replace("{1}", m2);
            if (!string.IsNullOrEmpty(m3)) message = message.Replace("{2}", m3);
            if (!string.IsNullOrEmpty(m4)) message = message.Replace("{3}", m4);

            //String.Format("Invalid Student Name: {0}", name)
            return message;
        }
    }
}
