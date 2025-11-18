using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnmenuService
    {
        ListResponse<GNMENU> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNMENU> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNMENU> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNMENU> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNMENU> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNMENU> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNMENU> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNMENU> Ncch_Add_NLog(GNMENU gnmenu, Global global);
        StandardResponse<GNMENU> Ncch_Update_Log(GNMENU gnmenu,GNMENU oldGnmenu, Global global);
        StandardResponse<GNMENU> Ncch_UpdateAktifPasif_Log(GNMENU gnmenu, Global global);
        StandardResponse<GNMENU> Ncch_Delete_Log(GNMENU gnmenu, Global global);

        #region ClientFunc

        //StandardResponse DegisiklikKaydet(ChangeRecords<GNMENU> records, Global global);
        ListResponse<GNMENU> Ncch_MenuProListGetir_NLog(Global global, string tipKod, bool yetkiKontrol = true);
        ListResponse<GNMENU> Ncch_GetListParentByProkod_NLog(Global global, string prokod, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
