using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGndpnoService
    {
        ListResponse<GNDPNO> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPNO> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPNO> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPNO> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPNO> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNDPNO> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNDPNO> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNDPNO> Ncch_Add_NLog(GNDPNO gndpno, Global global);
        StandardResponse<GNDPNO> Ncch_Update_Log(GNDPNO gndpno,GNDPNO oldGndpno, Global global);
        StandardResponse<GNDPNO> Ncch_UpdateAktifPasif_Log(GNDPNO gndpno, Global global);
        StandardResponse<GNDPNO> Ncch_Delete_Log(GNDPNO gndpno, Global global);

        #region ClientFunc

        StandardResponse<GNDPNO> Ncch_GetByDepoKodUretimYeri_NLog(string uretimYer, string depoKod, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
