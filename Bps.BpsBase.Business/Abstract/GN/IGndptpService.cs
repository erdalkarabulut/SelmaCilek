using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGndptpService
    {
        ListResponse<GNDPTP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPTP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPTP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPTP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPTP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNDPTP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNDPTP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNDPTP> Ncch_Add_NLog(GNDPTP gndptp, Global global);
        StandardResponse<GNDPTP> Ncch_Update_Log(GNDPTP gndptp,GNDPTP oldGndptp, Global global);
        StandardResponse<GNDPTP> Ncch_UpdateAktifPasif_Log(GNDPTP gndptp, Global global);
        StandardResponse<GNDPTP> Ncch_Delete_Log(GNDPTP gndptp, Global global);

        #region ClientFunc

        ListResponse<GNDPTP> Cch_GetListByDepoKd_NLog(string depoKd, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
