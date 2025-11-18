using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnkxmlService
    {
        ListResponse<GNKXML> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKXML> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKXML> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKXML> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKXML> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNKXML> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNKXML> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNKXML> Ncch_Add_NLog(GNKXML gnkxml, Global global);
        StandardResponse<GNKXML> Ncch_Update_Log(GNKXML gnkxml,GNKXML oldGnkxml, Global global);
        StandardResponse<GNKXML> Ncch_UpdateAktifPasif_Log(GNKXML gnkxml, Global global);
        StandardResponse<GNKXML> Ncch_Delete_Log(GNKXML gnkxml, Global global);

        #region ClientFunc

        ListResponse<dynamic> Ncch_GetSpecificColumnsWhere_NLog(string kulKod, string menuName, int menutag, int gridtag, Global global);
        StandardResponse<GNKXML> Ncch_GetBy_NLog(string kulKod, string menuName, int menutag, int gridtag, string gridText, Global global);
        StandardResponse<GNKXML> Ncch_GetByVarsayilan_NLog(string kulKod, string menuName, int menuTag, int gridTag);

        #endregion ClientFunc
    }
}
