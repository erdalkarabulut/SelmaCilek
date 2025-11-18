using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStolcuService
    {
        ListResponse<STOLCU> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STOLCU> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STOLCU> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STOLCU> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STOLCU> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STOLCU> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STOLCU> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STOLCU> Ncch_Add_NLog(STOLCU stolcu, Global global);
        StandardResponse<STOLCU> Ncch_Update_Log(STOLCU stolcu,STOLCU oldStolcu, Global global);
        StandardResponse<STOLCU> Ncch_UpdateAktifPasif_Log(STOLCU stolcu, Global global);
        StandardResponse<STOLCU> Ncch_Delete_Log(STOLCU stolcu, Global global);

        #region ClientFunc

        ListResponse<STOLCU> Ncch_GetByStKod_NLog(string stokKod, Global global, bool yetkiKontrol = true);
        StandardResponse Ncch_DeleteByStKod_NLog(string stokKod, Global global);

        #endregion ClientFunc
    }
}
