using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SN
{
    public interface ISntynnService
    {
        ListResponse<SNTYNN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNTYNN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNTYNN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNTYNN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNTYNN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SNTYNN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SNTYNN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SNTYNN> Ncch_Add_NLog(SNTYNN sntynn, Global global);
        StandardResponse<SNTYNN> Ncch_Update_Log(SNTYNN sntynn,SNTYNN oldSntynn, Global global);
        StandardResponse<SNTYNN> Ncch_UpdateAktifPasif_Log(SNTYNN sntynn, Global global);
        StandardResponse<SNTYNN> Ncch_Delete_Log(SNTYNN sntynn, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
