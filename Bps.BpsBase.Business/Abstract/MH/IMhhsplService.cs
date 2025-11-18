using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.MH;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.MH
{
    public interface IMhhsplService
    {
        ListResponse<MHHSPL> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<MHHSPL> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<MHHSPL> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<MHHSPL> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<MHHSPL> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<MHHSPL> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<MHHSPL> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<MHHSPL> Ncch_Add_NLog(MHHSPL mhhspl, Global global);
        StandardResponse<MHHSPL> Ncch_Update_Log(MHHSPL mhhspl,MHHSPL oldMhhspl, Global global);
        StandardResponse<MHHSPL> Ncch_UpdateAktifPasif_Log(MHHSPL mhhspl, Global global);
        StandardResponse<MHHSPL> Ncch_Delete_Log(MHHSPL mhhspl, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
