using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnmesjService
    {
        ListResponse<GNMESJ> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNMESJ> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNMESJ> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNMESJ> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNMESJ> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNMESJ> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNMESJ> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNMESJ> Ncch_Add_NLog(GNMESJ gnmesj, Global global);
        StandardResponse<GNMESJ> Ncch_Update_Log(GNMESJ gnmesj,GNMESJ oldGnmesj, Global global);
        StandardResponse<GNMESJ> Ncch_UpdateAktifPasif_Log(GNMESJ gnmesj, Global global);
        StandardResponse<GNMESJ> Ncch_Delete_Log(GNMESJ gnmesj, Global global);

        #region ClientFunc

        ListResponse<GNMESJ> GetListByLangkd(Global global, string langkd, bool yetkiKontrol = true);
        StandardResponse<GNMESJ> GetMesajDirect(Global global, string msjNo, string m1 = null, string m2 = null, string m3 = null, string m4 = null, string mesajKod = null);

        #endregion ClientFunc
    }
}
