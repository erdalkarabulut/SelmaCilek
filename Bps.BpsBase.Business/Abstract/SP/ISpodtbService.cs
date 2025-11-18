using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SP
{
    public interface ISpodtbService
    {
        ListResponse<SPODTB> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPODTB> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPODTB> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPODTB> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPODTB> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SPODTB> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SPODTB> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SPODTB> Ncch_Add_NLog(SPODTB spodtb, Global global);
        StandardResponse<SPODTB> Ncch_Update_Log(SPODTB spodtb,SPODTB oldSpodtb, Global global);
        StandardResponse<SPODTB> Ncch_UpdateAktifPasif_Log(SPODTB spodtb, Global global);
        StandardResponse<SPODTB> Ncch_Delete_Log(SPODTB spodtb, Global global);

        #region ClientFunc

        ListResponse<SPODTB> Ncch_GetListByBelgeNo_NLog(Global global, string belgeNo);
        StandardResponse<SPODTB> Ncch_DeleteKosul_Log(SPODTB spkosl, Global global);

        #endregion ClientFunc
    }
}
