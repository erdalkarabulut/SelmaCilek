using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStvuryService
    {
        ListResponse<STVURY> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STVURY> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STVURY> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STVURY> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STVURY> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STVURY> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STVURY> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STVURY> Ncch_Add_NLog(STVURY stvury, Global global);
        StandardResponse<STVURY> Ncch_Update_Log(STVURY stvury,STVURY oldStvury, Global global);
        StandardResponse<STVURY> Ncch_UpdateAktifPasif_Log(STVURY stvury, Global global);
        StandardResponse<STVURY> Ncch_Delete_Log(STVURY stvury, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
