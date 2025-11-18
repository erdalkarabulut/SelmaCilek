using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.GN.Single;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnevrkService
    {
        ListResponse<GNEVRK> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNEVRK> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNEVRK> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNEVRK> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNEVRK> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNEVRK> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNEVRK> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNEVRK> Ncch_Add_NLog(GNEVRK gnevrk, Global global);
        StandardResponse<GNEVRK> Ncch_Update_Log(GNEVRK gnevrk,GNEVRK oldGnevrk, Global global);
        StandardResponse<GNEVRK> Ncch_UpdateAktifPasif_Log(GNEVRK gnevrk, Global global);
        StandardResponse<GNEVRK> Ncch_Delete_Log(GNEVRK gnevrk, Global global);

        #region ClientFunc

        ListResponse<DbTablesModel> GetDbTables();
        //StandardResponse<GNEVRK> Ncch_GetByIndexParam_NLog(EvrakNoUretParamModel param, Global global, bool yetkiKontrol = true);
        //StandardResponse<string> EvrakNoUret(Global global, EvrakNoUretParamModel paramModel);
        StandardResponse<string> Ncch_EvrakNoUret_NLog(Global global, EvrakNoUretParamModel paramModel);

        StandardResponse<GNEVRK> Ncch_GetEvrak_NLog(Global global, EvrakNoUretParamModel paramModel, int? _year);

        #endregion ClientFunc
    }
}
