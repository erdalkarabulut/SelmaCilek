using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.CM;


#region ClientUsing
using Bps.BpsBase.Entities.Models.CM.Single;
#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.CM
{
    public interface ICmkartService
    {
        ListResponse<CMKART> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CMKART> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CMKART> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CMKART> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CMKART> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<CMKART> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<CMKART> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<CMKART> Ncch_Add_NLog(CMKART cmkart, Global global);
        StandardResponse<CMKART> Ncch_Update_Log(CMKART cmkart,CMKART oldCmkart, Global global);
        StandardResponse<CMKART> Ncch_UpdateAktifPasif_Log(CMKART cmkart, Global global);
        StandardResponse<CMKART> Ncch_Delete_Log(CMKART cmkart, Global global);

        #region ClientFunc

        ListResponse<CMKART> Ncch_GetListByParam_NLog(CrmKartParamModel param, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
