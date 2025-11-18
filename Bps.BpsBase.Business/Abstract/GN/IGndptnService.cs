using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

using Bps.BpsBase.Entities.Models.GN.Single;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGndptnService
    {
        ListResponse<GNDPTN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPTN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPTN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPTN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNDPTN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNDPTN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNDPTN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNDPTN> Ncch_Add_NLog(GNDPTN gndptn, Global global);
        StandardResponse<GNDPTN> Ncch_Update_Log(GNDPTN gndptn,GNDPTN oldGndptn, Global global);
        StandardResponse<GNDPTN> Ncch_UpdateAktifPasif_Log(GNDPTN gndptn, Global global);
        StandardResponse<GNDPTN> Ncch_Delete_Log(GNDPTN gndptn, Global global);

        #region ClientFunc

        ListResponse<GNDPTN> Cch_GetListByUretimYeri_NLog(string uretimYeri, Global global);
        StandardResponse Ncch_Kaydet_Log(GenelKayitModel model, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
