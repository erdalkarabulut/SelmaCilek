using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStvmizService
    {
        ListResponse<STVMIZ> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STVMIZ> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STVMIZ> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STVMIZ> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STVMIZ> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STVMIZ> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STVMIZ> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STVMIZ> Ncch_Add_NLog(STVMIZ stvmiz, Global global);
        StandardResponse<STVMIZ> Ncch_Update_Log(STVMIZ stvmiz,STVMIZ oldStvmiz, Global global);
        StandardResponse<STVMIZ> Ncch_UpdateAktifPasif_Log(STVMIZ stvmiz, Global global);
        StandardResponse<STVMIZ> Ncch_Delete_Log(STVMIZ stvmiz, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
