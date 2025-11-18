using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnfileService
    {
        ListResponse<GNFILE> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNFILE> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNFILE> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNFILE> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNFILE> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNFILE> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNFILE> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNFILE> Ncch_Add_NLog(GNFILE gnfile, Global global);
        StandardResponse<GNFILE> Ncch_Update_Log(GNFILE gnfile,GNFILE oldGnfile, Global global);
        StandardResponse<GNFILE> Ncch_UpdateAktifPasif_Log(GNFILE gnfile, Global global);
        StandardResponse<GNFILE> Ncch_Delete_Log(GNFILE gnfile, Global global);

        #region ClientFunc

        StandardResponse GridTopluAktar(byte[] fileData, string fileName, string type, Global global);
        StandardResponse<GNFILE> Cch_GetDefaultFile_NLog(Global global, string tableName, int tableId);
        ListResponse<GNFILE> Ncch_GetUserFiles_NLog(Global global, string tableName, int id);
        StandardResponse<GNFILE> Ncch_SaveorUpdate_Log(string tableName, int? tableId, int? fileType, string tempPath, string destPath, Global global);
        StandardResponse<GNFILE> Ncch_SaveTemp_Log(string key, string tableName, int? tableId, Global global);
        ListResponse<GNFILE> Cch_GetListByTableId_NLog(Global global, string tableName, int tableId);
        StandardResponse<GNFILE> Ncch_SaveFileManager_Log(string tableName, int? tableId, Global global);
        StandardResponse<GNFILE> Ncch_Save_NLog(GNFILE gnfile, Global global);

        StandardResponse<GNFILE> Ncch_GetByFileName_NLog(string tableName, int? tableId, string fileName, Global global);
        StandardResponse<GNFILE> Ncch_DeleteFull_Log(GNFILE gnfile, Global global);

        #endregion ClientFunc
    }
}
