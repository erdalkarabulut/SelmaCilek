using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract
{
    public interface ISirketService
    {
        ListResponse<SIRKET> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SIRKET> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SIRKET> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SIRKET> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SIRKET> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SIRKET> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SIRKET> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SIRKET> Ncch_Add_NLog(SIRKET sirket, Global global);
        StandardResponse<SIRKET> Ncch_Update_Log(SIRKET sirket,SIRKET oldSirket, Global global);
        StandardResponse<SIRKET> Ncch_UpdateAktifPasif_Log(SIRKET sirket, Global global);
        StandardResponse<SIRKET> Ncch_Delete_Log(SIRKET sirket, Global global);

        #region ClientFunc

        ListResponse<SIRKET> GetResmiSirketList();

        StandardResponse<SIRKET> Ncch_GetKarsiSirket_Log(Global global);

        #endregion ClientFunc
    }
}
