using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SP
{
    public interface ISpdkdrService
    {
        ListResponse<SPDKDR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPDKDR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPDKDR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPDKDR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPDKDR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SPDKDR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SPDKDR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SPDKDR> Ncch_Add_NLog(SPDKDR spdkdr, Global global);
        StandardResponse<SPDKDR> Ncch_Update_Log(SPDKDR spdkdr,SPDKDR oldSpdkdr, Global global);
        StandardResponse<SPDKDR> Ncch_UpdateAktifPasif_Log(SPDKDR spdkdr, Global global);
        StandardResponse<SPDKDR> Ncch_Delete_Log(SPDKDR spdkdr, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
