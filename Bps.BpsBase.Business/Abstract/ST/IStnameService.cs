using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStnameService
    {
        ListResponse<STNAME> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STNAME> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STNAME> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STNAME> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STNAME> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STNAME> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STNAME> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STNAME> Ncch_Add_NLog(STNAME stname, Global global);
        StandardResponse<STNAME> Ncch_Update_Log(STNAME stname,STNAME oldStname, Global global);
        StandardResponse<STNAME> Ncch_UpdateAktifPasif_Log(STNAME stname, Global global);
        StandardResponse<STNAME> Ncch_Delete_Log(STNAME stname, Global global);

        #region ClientFunc

        ListResponse<STNAME> Cch_GetListByStokKodu_NLog(Global global, string stokKodu, bool yetkiKontrol = true);
        StandardResponse<STNAME> Cch_GetByStokKoduLangkd_NLog(Global global, string stokKodu, string langKd = "", bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
