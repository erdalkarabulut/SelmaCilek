using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.UA;


#region ClientUsing
using Bps.BpsBase.Entities.Concrete.UR;
#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.UA
{
    public interface IUastrtService
    {
        ListResponse<UASTRT> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UASTRT> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UASTRT> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UASTRT> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UASTRT> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<UASTRT> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<UASTRT> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<UASTRT> Ncch_Add_NLog(UASTRT uastrt, Global global);
        StandardResponse<UASTRT> Ncch_Update_Log(UASTRT uastrt,UASTRT oldUastrt, Global global);
        StandardResponse<UASTRT> Ncch_UpdateAktifPasif_Log(UASTRT uastrt, Global global);
        StandardResponse<UASTRT> Ncch_Delete_Log(UASTRT uastrt, Global global);

        #region ClientFunc

        ListResponse<UASTRT> Ncch_UrunAgacStokRotaKaydet_Log(URAGAC uragac, List<string> operasyonList, Global global,
	        bool yetkiKontrol = true);

        ListResponse<UASTRT> Ncch_GetListByUrunAgacInfo_NLog(URAGAC uragac, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
