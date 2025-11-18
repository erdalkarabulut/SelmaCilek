using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SP
{
    public interface ISpftopService
    {
        ListResponse<SPFTOP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFTOP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFTOP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFTOP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFTOP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SPFTOP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SPFTOP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SPFTOP> Ncch_Add_NLog(SPFTOP spftop, Global global);
        StandardResponse<SPFTOP> Ncch_Update_Log(SPFTOP spftop,SPFTOP oldSpftop, Global global);
        StandardResponse<SPFTOP> Ncch_UpdateAktifPasif_Log(SPFTOP spftop, Global global);
        StandardResponse<SPFTOP> Ncch_Delete_Log(SPFTOP spftop, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
