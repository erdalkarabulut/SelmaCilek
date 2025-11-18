using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStkmihService
    {
        ListResponse<STKMIH> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKMIH> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKMIH> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKMIH> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKMIH> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STKMIH> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STKMIH> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STKMIH> Ncch_Add_NLog(STKMIH stkmih, Global global);
        StandardResponse<STKMIH> Ncch_Update_Log(STKMIH stkmih,STKMIH oldStkmih, Global global);
        StandardResponse<STKMIH> Ncch_UpdateAktifPasif_Log(STKMIH stkmih, Global global);
        StandardResponse<STKMIH> Ncch_Delete_Log(STKMIH stkmih, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
