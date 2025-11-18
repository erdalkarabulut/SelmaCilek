using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.KS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.KS
{
    public interface IKskasaService
    {
        ListResponse<KSKASA> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<KSKASA> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<KSKASA> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<KSKASA> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<KSKASA> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<KSKASA> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<KSKASA> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<KSKASA> Ncch_Add_NLog(KSKASA kskasa, Global global);
        StandardResponse<KSKASA> Ncch_Update_Log(KSKASA kskasa,KSKASA oldKskasa, Global global);
        StandardResponse<KSKASA> Ncch_UpdateAktifPasif_Log(KSKASA kskasa, Global global);
        StandardResponse<KSKASA> Ncch_Delete_Log(KSKASA kskasa, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
