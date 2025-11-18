using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnklopService
    {
        ListResponse<GNKLOP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKLOP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKLOP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKLOP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKLOP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNKLOP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNKLOP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNKLOP> Ncch_Add_NLog(GNKLOP gnklop, Global global);
        StandardResponse<GNKLOP> Ncch_Update_Log(GNKLOP gnklop,GNKLOP oldGnklop, Global global);
        StandardResponse<GNKLOP> Ncch_UpdateAktifPasif_Log(GNKLOP gnklop, Global global);
        StandardResponse<GNKLOP> Ncch_Delete_Log(GNKLOP gnklop, Global global);

        #region ClientFunc

        ListResponse<GNKLOP> Ncch_GetListByPersonelId_NLog(int personelId, Global global, bool yetkiKontrol = true);
        
        #endregion ClientFunc
    }
}
