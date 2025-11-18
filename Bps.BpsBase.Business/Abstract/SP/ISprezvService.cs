using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SP
{
    public interface ISprezvService
    {
        ListResponse<SPREZV> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPREZV> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPREZV> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPREZV> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPREZV> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SPREZV> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SPREZV> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SPREZV> Ncch_Add_NLog(SPREZV sprezv, Global global);
        StandardResponse<SPREZV> Ncch_Update_Log(SPREZV sprezv,SPREZV oldSprezv, Global global);
        StandardResponse<SPREZV> Ncch_UpdateAktifPasif_Log(SPREZV sprezv, Global global);
        StandardResponse<SPREZV> Ncch_Delete_Log(SPREZV sprezv, Global global);

        #region ClientFunc

        ListResponse<SPREZV> Ncch_GetAcikList_NLog(Global global, bool yetkiKontrol = true);

        ListResponse<SPREZV> Ncch_GetListBySiparisBelgeNo_NLog(Global global, string siparisBelgeNo,
            bool yetkiKontrol = true);
        //ListResponse<SPREZV> Ncch_GetListByBelge_NLog(string belgeNo, Global global);
        //ListResponse<SPREZV> Ncch_GetListStokKodu_NLog(string belgeNo, Global global);

        #endregion ClientFunc
    }
}
