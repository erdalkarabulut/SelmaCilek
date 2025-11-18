using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStanagService
    {
        ListResponse<STANAG> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STANAG> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STANAG> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STANAG> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STANAG> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STANAG> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STANAG> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STANAG> Ncch_Add_NLog(STANAG stanag, Global global);
        StandardResponse<STANAG> Ncch_Update_Log(STANAG stanag,STANAG oldStanag, Global global);
        StandardResponse<STANAG> Ncch_UpdateAktifPasif_Log(STANAG stanag, Global global);
        StandardResponse<STANAG> Ncch_Delete_Log(STANAG stanag, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
