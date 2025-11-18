using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGndpzmService
    {
        ListResponse<GNDPZM> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPZM> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPZM> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPZM> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPZM> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNDPZM> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNDPZM> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNDPZM> Ncch_Add_NLog(GNDPZM gndpzm, Global global);
        StandardResponse<GNDPZM> Ncch_Update_Log(GNDPZM gndpzm,GNDPZM oldGndpzm, Global global);
        StandardResponse<GNDPZM> Ncch_UpdateAktifPasif_Log(GNDPZM gndpzm, Global global);
        StandardResponse<GNDPZM> Ncch_Delete_Log(GNDPZM gndpzm, Global global);

        #region ClientFunc

        ListResponse<GNDPZM> Ncch_GetPersonelMobilDepoList_NLog(Global global, int personelId, bool yetkiKontrol = true);
        ListResponse<GNDPZM> Ncch_GetByPersonelId_NLog(int personelId, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
