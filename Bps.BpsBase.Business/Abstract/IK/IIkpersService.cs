using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.IK;

#region ClientUsing

using Bps.BpsBase.Entities.Models.IK.Listed;
using Bps.BpsBase.Entities.Concrete.GN;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.IK
{
    public interface IIkpersService
    {
        ListResponse<IKPERS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<IKPERS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<IKPERS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<IKPERS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<IKPERS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<IKPERS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<IKPERS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<IKPERS> Ncch_Add_NLog(IKPERS ikpers, Global global);
        StandardResponse<IKPERS> Ncch_Update_Log(IKPERS ikpers,IKPERS oldIkpers, Global global);
        StandardResponse<IKPERS> Ncch_UpdateAktifPasif_Log(IKPERS ikpers, Global global);
        StandardResponse<IKPERS> Ncch_Delete_Log(IKPERS ikpers, Global global);

        #region ClientFunc

        StandardResponse<IKPERS> Ncch_AddWithImage_NLog(IKPERS ikpers, Global global, string imagePath);

        StandardResponse<IKPERS> Ncch_UpdateWithImage_Log(IKPERS ikpers, IKPERS oldIkpers, Global global, string imagePath);

        ListResponse<IKPERS> Ncch_GetListByOnlineDep_NLog(Global global, bool yetkiKontrol = true);

        ListResponse<IKPERS> Ncch_GetList_NLog(Global global, bool yetkiKontrol = true);

        ListResponse<IkpersSicilAdPozModel>
            Ncch_GetListPersonelSicilAdPoz_NLog(Global global, bool yetkiKontrol = true);

        StandardResponse Ncch_PersonelKaydet_Log(Global global, IKPERS model, List<GNDPZM> depos, List<GNKLOP> personelOperasyonList, List<Core.Utilities.WinForm.Grid> grids, string _action, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
