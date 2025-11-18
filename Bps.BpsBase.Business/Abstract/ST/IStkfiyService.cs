using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStkfiyService
    {
        ListResponse<STKFIY> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKFIY> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKFIY> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKFIY> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKFIY> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STKFIY> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STKFIY> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STKFIY> Ncch_Add_NLog(STKFIY stkfiy, Global global);
        StandardResponse<STKFIY> Ncch_Update_Log(STKFIY stkfiy,STKFIY oldStkfiy, Global global);
        StandardResponse<STKFIY> Ncch_UpdateAktifPasif_Log(STKFIY stkfiy, Global global);
        StandardResponse<STKFIY> Ncch_Delete_Log(STKFIY stkfiy, Global global);

        #region ClientFunc

        ListResponse<STKFIY> Cch_GetListByStfyno_NLog(Global global, int stfyno, bool yetkiKontrol = true);

        StandardResponse<STKFIY> Ncch_Save_NLog(List<STKFIY> stkfiyList, STKFYT stkfyt, Global global);

        StandardResponse<STKFIY> Ncch_GetFiyatByFytNoStokKod_NLog(int? fytNo, string stokKod, Global global);

        #endregion ClientFunc
    }
}
