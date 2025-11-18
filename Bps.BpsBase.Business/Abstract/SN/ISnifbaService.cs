using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SN
{
    public interface ISnifbaService
    {
        ListResponse<SNIFBA> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNIFBA> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNIFBA> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNIFBA> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNIFBA> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SNIFBA> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SNIFBA> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SNIFBA> Ncch_Add_NLog(SNIFBA snifba, Global global);
        StandardResponse<SNIFBA> Ncch_Update_Log(SNIFBA snifba,SNIFBA oldSnifba, Global global);
        StandardResponse<SNIFBA> Ncch_UpdateAktifPasif_Log(SNIFBA snifba, Global global);
        StandardResponse<SNIFBA> Ncch_Delete_Log(SNIFBA snifba, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
