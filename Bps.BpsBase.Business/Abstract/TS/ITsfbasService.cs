using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.TS;

#region ClientUsing

using Bps.BpsBase.Entities.Models.TS;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.TS
{
    public interface ITsfbasService
    {
        ListResponse<TSFBAS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<TSFBAS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<TSFBAS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<TSFBAS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<TSFBAS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<TSFBAS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<TSFBAS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<TSFBAS> Ncch_Add_NLog(TSFBAS tsfbas, Global global);
        StandardResponse<TSFBAS> Ncch_Update_Log(TSFBAS tsfbas,TSFBAS oldTsfbas, Global global);
        StandardResponse<TSFBAS> Ncch_UpdateAktifPasif_Log(TSFBAS tsfbas, Global global);
        StandardResponse<TSFBAS> Ncch_Delete_Log(TSFBAS tsfbas, Global global);

        #region ClientFunc

        ListResponse<TSFBAS> Cch_GetListByParam_NLog(TeslimatParamModel param, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
