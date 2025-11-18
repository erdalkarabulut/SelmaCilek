using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SP
{
    public interface ISpuropService
    {
        ListResponse<SPUROP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPUROP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPUROP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPUROP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPUROP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SPUROP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SPUROP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SPUROP> Ncch_Add_NLog(SPUROP spurop, Global global);
        StandardResponse<SPUROP> Ncch_Update_Log(SPUROP spurop,SPUROP oldSpurop, Global global);
        StandardResponse<SPUROP> Ncch_UpdateAktifPasif_Log(SPUROP spurop, Global global);
        StandardResponse<SPUROP> Ncch_Delete_Log(SPUROP spurop, Global global);

        #region ClientFunc

        ListResponse<SPUROP> Ncch_GetListByBelgeNo_NLog(string belgeNo, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
