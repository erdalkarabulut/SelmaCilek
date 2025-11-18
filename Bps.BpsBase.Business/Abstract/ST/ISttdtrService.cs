using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface ISttdtrService
    {
        ListResponse<STTDTR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STTDTR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STTDTR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STTDTR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STTDTR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STTDTR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STTDTR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STTDTR> Ncch_Add_NLog(STTDTR sttdtr, Global global);
        StandardResponse<STTDTR> Ncch_Update_Log(STTDTR sttdtr,STTDTR oldSttdtr, Global global);
        StandardResponse<STTDTR> Ncch_UpdateAktifPasif_Log(STTDTR sttdtr, Global global);
        StandardResponse<STTDTR> Ncch_Delete_Log(STTDTR sttdtr, Global global);

        #region ClientFunc

        ListResponse<STTDTR> Cch_GetListByUretimYeri_NLog(string uretimYeri, Global global);

        #endregion ClientFunc
    }
}
