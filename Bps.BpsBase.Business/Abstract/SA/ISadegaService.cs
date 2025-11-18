using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SA
{
    public interface ISadegaService
    {
        ListResponse<SADEGA> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SADEGA> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SADEGA> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SADEGA> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SADEGA> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SADEGA> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SADEGA> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SADEGA> Ncch_Add_NLog(SADEGA sadega, Global global);
        StandardResponse<SADEGA> Ncch_Update_Log(SADEGA sadega,SADEGA oldSadega, Global global);
        StandardResponse<SADEGA> Ncch_UpdateAktifPasif_Log(SADEGA sadega, Global global);
        StandardResponse<SADEGA> Ncch_Delete_Log(SADEGA sadega, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
