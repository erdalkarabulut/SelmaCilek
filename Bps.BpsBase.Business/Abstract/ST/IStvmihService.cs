using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStvmihService
    {
        ListResponse<STVMIH> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STVMIH> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STVMIH> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STVMIH> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STVMIH> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STVMIH> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STVMIH> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STVMIH> Ncch_Add_NLog(STVMIH stvmih, Global global);
        StandardResponse<STVMIH> Ncch_Update_Log(STVMIH stvmih,STVMIH oldStvmih, Global global);
        StandardResponse<STVMIH> Ncch_UpdateAktifPasif_Log(STVMIH stvmih, Global global);
        StandardResponse<STVMIH> Ncch_Delete_Log(STVMIH stvmih, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
