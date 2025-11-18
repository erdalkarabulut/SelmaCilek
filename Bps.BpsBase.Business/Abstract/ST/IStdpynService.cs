using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStdpynService
    {
        ListResponse<STDPYN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDPYN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDPYN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDPYN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDPYN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STDPYN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STDPYN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STDPYN> Ncch_Add_NLog(STDPYN stdpyn, Global global);
        StandardResponse<STDPYN> Ncch_Update_Log(STDPYN stdpyn,STDPYN oldStdpyn, Global global);
        StandardResponse<STDPYN> Ncch_UpdateAktifPasif_Log(STDPYN stdpyn, Global global);
        StandardResponse<STDPYN> Ncch_Delete_Log(STDPYN stdpyn, Global global);

        #region ClientFunc

        ListResponse<STDPYN> Cch_GetListByStokKodu_NLog(string stokKodu, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
