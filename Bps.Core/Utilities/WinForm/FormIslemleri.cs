using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.Core.Entities;
using Bps.Core.Web.Model;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using Microsoft.Office.Interop.Excel;
using TextBox = System.Windows.Forms.TextBox;

namespace Bps.Core.Utilities.WinForm
{
    public class FormIslemleri
    {
        public delegate void UpdateControlTextDlg(Control control, string tableName, int completed, int total);

        public static bool FormYetki(TileNavPane _pane, ProjeMenuListed yetkiModel)
        {
            for (int i = 0; i < _pane.Buttons.Count; i++)
            {
                Type tip;
                tip = _pane.Buttons[i].GetType();
                if (tip.Name == "NavButton")
                {
                    NavButton items = (NavButton)_pane.Buttons[i];
                    if (yetkiModel == null)
                    {
                        items.Enabled = false;
                    }
                    else
                    {
                        if (items.Tag != null)
                        {
                            switch (items.Tag.ToString())
                            {
                                case "1":
                                    {
                                        if (yetkiModel.EKLEME)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[0];
                                        }
                                        else
                                        {
                                            items.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[1];
                                        }
                                        break;
                                    }
                                case "2":
                                    {
                                        if (yetkiModel.DEGIST)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[6];
                                        }
                                        else
                                        {
                                            items.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[7];
                                        }
                                        break;
                                    }
                                case "3":
                                    {
                                        if (yetkiModel.KAYDET)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[12];
                                        }
                                        else
                                        {
                                            items.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[13];
                                        }
                                        break;
                                    }
                                case "4":
                                    {
                                        if (yetkiModel.SILMEK)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[14];
                                        }
                                        else
                                        {
                                            items.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public static bool ButonKontrol(TileNavPane _pane, int _tag, ProjeMenuListed yetkiModel)
        {
            //DevExpress.Utils.AppearanceObject appearanceObject = new AppearanceObject();
            
            for (int i = 0; i < _pane.Buttons.Count; i++)
            {
                Type tip;
                tip = _pane.Buttons[i].GetType();
                if (tip.Name == "NavButton")
                {
                    NavButton items = (NavButton)_pane.Buttons[i];

                    if (items.Tag != null)
                    {
                        if (_tag == 1)
                        {
                            switch (items.Tag.ToString())
                            {
                                case "1":
                                    {
                                        if (yetkiModel.EKLEME == true)
                                        {
                                            items.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[1];
                                        }
                                        break;
                                    }
                                case "2":
                                    {
                                        if (yetkiModel.DEGIST == true)
                                        {
                                            items.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[7];
                                        }

                                        break;
                                    }
                                case "3":
                                    {
                                        if (yetkiModel.KAYDET == true)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[12];
                                        }

                                        break;
                                    }
                                case "4":
                                    {
                                        if (yetkiModel.SILMEK == true)
                                        {
                                            items.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }

                                        break;
                                    }
                                case "5":
                                    {

                                        items.Enabled = true;
                                        //appearanceObject = items.Appearance;
                                        //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                        //items.Glyph = _imageList.Images[4];
                                        break;
                                    }
                            }
                        }
                        if (_tag == 2)
                        {
                            switch (items.Tag.ToString())
                            {
                                case "1":
                                    {
                                        if (yetkiModel.EKLEME == true)
                                        {
                                            items.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[1];
                                        }
                                        break;
                                    }
                                case "2":
                                    {
                                        if (yetkiModel.DEGIST == true)
                                        {
                                            items.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[7];
                                        }

                                        break;
                                    }
                                case "3":
                                    {
                                        if (yetkiModel.KAYDET == true)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[12];
                                        }

                                        break;
                                    }
                                case "4":
                                    {
                                        if (yetkiModel.SILMEK == true)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }

                                        break;
                                    }
                                case "5":
                                    {

                                        items.Enabled = true;
                                        //appearanceObject = items.Appearance;
                                        //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                        //items.Glyph = _imageList.Images[4];
                                        break;
                                    }
                            }
                        }
                        if (_tag == 3)
                        {
                            switch (items.Tag.ToString())
                            {
                                case "1":
                                    {
                                        if (yetkiModel.EKLEME == true)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[1];
                                        }
                                        break;
                                    }
                                case "2":
                                    {
                                        if (yetkiModel.DEGIST == true)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[7];
                                        }

                                        break;
                                    }
                                case "3":
                                    {
                                        if (yetkiModel.KAYDET == true)
                                        {
                                            items.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[12];
                                        }

                                        break;
                                    }
                                case "4":
                                    {
                                        if (yetkiModel.SILMEK == true)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }

                                        break;
                                    }
                                case "5":
                                    {

                                        items.Enabled = false;
                                        //appearanceObject = items.Appearance;
                                        //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                        //items.Glyph = _imageList.Images[4];
                                        break;
                                    }
                            }
                        }

                        if (_tag == 4)
                        {
                            switch (items.Tag.ToString())
                            {
                                case "1":
                                    {
                                        if (yetkiModel.EKLEME == true)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[0];
                                        }

                                        break;
                                    }
                                case "2":
                                    {
                                        if (yetkiModel.DEGIST == true)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[6];
                                        }

                                        break;
                                    }
                                case "3":
                                    {
                                        if (yetkiModel.KAYDET == true)
                                        {
                                            items.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[13];
                                        }

                                        break;
                                    }
                                case "4":
                                    {
                                        if (yetkiModel.SILMEK == true)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[14];
                                        }

                                        break;
                                    }
                                case "5":
                                    {
                                        items.Enabled = false;
                                        //appearanceObject = items.Appearance;
                                        //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                        //items.Glyph = _imageList.Images[14];
                                        break;
                                    }
                            }
                        }
                        if (_tag == 5)
                        {
                            switch (items.Tag.ToString())
                            {
                                case "1":
                                    {
                                        if (yetkiModel.EKLEME == true)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[0];
                                        }

                                        break;
                                    }
                                case "2":
                                    {
                                        if (yetkiModel.DEGIST == true)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[6];
                                        }

                                        break;
                                    }
                                case "3":
                                    {
                                        if (yetkiModel.KAYDET == true)
                                        {
                                            items.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[12];
                                        }

                                        break;
                                    }
                                case "4":
                                    {
                                        if (yetkiModel.SILMEK == true)
                                        {
                                            items.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[14];
                                        }

                                        break;
                                    }
                                case "5":
                                    {
                                        items.Enabled = false;
                                        //appearanceObject = items.Appearance;
                                        //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                        //items.Glyph = _imageList.Images[5];
                                        break;
                                    }
                            }
                        }
                    }

                }
            }

            return true;
        }

        public static bool FormYetki2(BarManager barManager, ProjeMenuListed yetkiModel, dynamic yetkiOrtam = null)
        {
            for (int i = 0; i < barManager.Items.Count; i++)
            {
                string tip = barManager.Items[i].GetType().Name;
                if (tip == "BarButtonItem")
                {
                    BarButtonItem barButton = (BarButtonItem)barManager.Items[i];
                    if (yetkiOrtam != null)
                    {
                        foreach (var ortamitem in yetkiOrtam)
                        {
                            if (Convert.ToInt32(ortamitem.MNUTAG) == Convert.ToInt32(barButton.Tag))
                            {
                                barButton.Visibility = BarItemVisibility.Always;
                                barButton.Enabled = true;
                            }
                        }
                    }
                    if (yetkiModel == null)
                    {
                        barButton.Enabled = false;
                    }
                    else
                    {
                        if (barButton.Tag != null)
                        {
                            switch (barButton.Tag.ToString())
                            {
                                case "1":
                                    {
                                        if (yetkiModel.EKLEME)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[0];
                                        }
                                        else
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[1];
                                        }
                                        break;
                                    }
                                case "2":
                                    {
                                        if (yetkiModel.DEGIST)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[6];
                                        }
                                        else
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[7];
                                        }
                                        break;
                                    }
                                case "3":
                                    {
                                        if (yetkiModel.KAYDET)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[12];
                                        }
                                        else
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[13];
                                        }
                                        break;
                                    }
                                case "4":
                                    {
                                        if (yetkiModel.SILMEK)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[14];
                                        }
                                        else
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }
                                        break;
                                    }
                                case "12":
                                    {
                                        if (yetkiModel.KOPYAL)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[14];
                                        }
                                        else
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                }
            }
            return true;
        }


        public enum ButtonNames
        {
            Ekle = 1,
            Degistir = 2,
            Kaydet = 3,
            Sil = 4,
            Vazgec = 5,
            Hidden = 6,
            Kopyala = 12
        }

        public static bool ButonKontrol2(BarManager barManager, int _tag, ProjeMenuListed yetkiModel)
        {
            for (int i = 0; i < barManager.Items.Count; i++)
            {
                string tip = barManager.Items[i].GetType().Name;
                if (tip == "BarButtonItem")
                {
                    BarButtonItem barButton = (BarButtonItem)barManager.Items[i];

                    if (barButton.Tag != null)
                    {
                        if (_tag == (int) ButtonNames.Ekle)
                        {
                            switch (barButton.Tag.ToString())
                            {
                                case "1":
                                    {
                                        if (yetkiModel.EKLEME == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[1];
                                        }
                                        break;
                                    }
                                case "2":
                                    {
                                        if (yetkiModel.DEGIST == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[7];
                                        }

                                        break;
                                    }
                                case "3":
                                    {
                                        if (yetkiModel.KAYDET == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[12];
                                        }

                                        break;
                                    }
                                case "4":
                                    {
                                        if (yetkiModel.SILMEK == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }

                                        break;
                                    }
                                case "5":
                                    {

                                        barButton.Enabled = true;
                                        //appearanceObject = items.Appearance;
                                        //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                        //items.Glyph = _imageList.Images[4];
                                        break;
                                    }
                                case "12":
                                    {
                                        if (yetkiModel.KOPYAL == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }

                                        break;
                                    }
                            }
                        }
                        if (_tag == (int)ButtonNames.Degistir)
                        {
                            switch (barButton.Tag.ToString())
                            {
                                case "1":
                                    {
                                        if (yetkiModel.EKLEME == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[1];
                                        }
                                        break;
                                    }
                                case "2":
                                    {
                                        if (yetkiModel.DEGIST == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[7];
                                        }

                                        break;
                                    }
                                case "3":
                                    {
                                        if (yetkiModel.KAYDET == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[12];
                                        }

                                        break;
                                    }
                                case "4":
                                    {
                                        if (yetkiModel.SILMEK == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }

                                        break;
                                    }
                                case "5":
                                    {

                                        barButton.Enabled = true;
                                        //appearanceObject = items.Appearance;
                                        //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                        //items.Glyph = _imageList.Images[4];
                                        break;
                                    }
                                case "12":
                                    {
                                        if (yetkiModel.KOPYAL == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }

                                        break;
                                    }
                            }
                        }
                        if (_tag == (int)ButtonNames.Kaydet)
                        {
                            switch (barButton.Tag.ToString())
                            {
                                case "1":
                                    {
                                        if (yetkiModel.EKLEME == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[1];
                                        }
                                        break;
                                    }
                                case "2":
                                    {
                                        if (yetkiModel.DEGIST == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[7];
                                        }

                                        break;
                                    }
                                case "3":
                                    {
                                        if (yetkiModel.KAYDET == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[12];
                                        }

                                        break;
                                    }
                                case "4":
                                    {
                                        if (yetkiModel.SILMEK == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }

                                        break;
                                    }
                                case "5":
                                    {

                                        barButton.Enabled = false;
                                        //appearanceObject = items.Appearance;
                                        //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                        //items.Glyph = _imageList.Images[4];
                                        break;
                                    }
                                case "12":
                                    {
                                        if (yetkiModel.KOPYAL == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }

                                        break;
                                    }
                            }
                        }

                        if (_tag == (int)ButtonNames.Sil)
                        {
                            switch (barButton.Tag.ToString())
                            {
                                case "1":
                                    {
                                        if (yetkiModel.EKLEME == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[0];
                                        }

                                        break;
                                    }
                                case "2":
                                    {
                                        if (yetkiModel.DEGIST == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[6];
                                        }

                                        break;
                                    }
                                case "3":
                                    {
                                        if (yetkiModel.KAYDET == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[13];
                                        }

                                        break;
                                    }
                                case "4":
                                    {
                                        if (yetkiModel.SILMEK == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[14];
                                        }

                                        break;
                                    }
                                case "5":
                                    {
                                        barButton.Enabled = false;
                                        //appearanceObject = items.Appearance;
                                        //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                        //items.Glyph = _imageList.Images[14];
                                        break;
                                    }
                                case "12":
                                    {
                                        if (yetkiModel.KOPYAL == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }

                                        break;
                                    }
                            }
                        }
                        if (_tag == (int)ButtonNames.Vazgec)
                        {
                            switch (barButton.Tag.ToString())
                            {
                                case "1":
                                    {
                                        if (yetkiModel.EKLEME == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[0];
                                        }

                                        break;
                                    }
                                case "2":
                                    {
                                        if (yetkiModel.DEGIST == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[6];
                                        }

                                        break;
                                    }
                                case "3":
                                    {
                                        if (yetkiModel.KAYDET == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[12];
                                        }

                                        break;
                                    }
                                case "4":
                                    {
                                        if (yetkiModel.SILMEK == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[14];
                                        }

                                        break;
                                    }
                                case "5":
                                    {
                                        barButton.Enabled = false;
                                        //appearanceObject = items.Appearance;
                                        //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                        //items.Glyph = _imageList.Images[5];
                                        break;
                                    }
                                case "12":
                                    {
                                        if (yetkiModel.KOPYAL == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }

                                        break;
                                    }
                            }
                        }
                        if (_tag == (int)ButtonNames.Kopyala)
                        {
                            switch (barButton.Tag.ToString())
                            {
                                case "1":
                                    {
                                        if (yetkiModel.EKLEME == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[0];
                                        }

                                        break;
                                    }
                                case "2":
                                    {
                                        if (yetkiModel.DEGIST == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[6];
                                        }

                                        break;
                                    }
                                case "3":
                                    {
                                        if (yetkiModel.KAYDET == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[12];
                                        }

                                        break;
                                    }
                                case "4":
                                    {
                                        if (yetkiModel.SILMEK == true)
                                        {
                                            barButton.Enabled = false;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.Empty;
                                            //items.Glyph = _imageList.Images[14];
                                        }

                                        break;
                                    }
                                case "12":
                                    {
                                        if (yetkiModel.KOPYAL == true)
                                        {
                                            barButton.Enabled = true;
                                            //appearanceObject = items.Appearance;
                                            //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                            //items.Glyph = _imageList.Images[15];
                                        }

                                        break;
                                    }
                                case "5":
                                    {
                                        barButton.Enabled = true;
                                        //appearanceObject = items.Appearance;
                                        //appearanceObject.BackColor = System.Drawing.Color.DarkGray;
                                        //items.Glyph = _imageList.Images[5];
                                        break;
                                    }
                            }
                        }
                    }

                }
            }

            return true;
        }

        public static void ClearStokKartTabPages(XtraTabControl tabControl)
        {
            foreach (XtraTabPage xtraTabPage in tabControl.TabPages)
            {
                if (xtraTabPage.PageVisible)
                {
                    //string tag = xtraTabPage.Tag.ToString();
                    foreach (Control control in xtraTabPage.Controls)
                    {
                        if (control is GroupControl)
                        {
                            ClearGroupControlControls((GroupControl)control);
                        }
                    }
                }
                xtraTabPage.PageVisible = false;
            }
        }

        public static void SetControlsReadonlyProperty(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is BaseEdit)
                    ((BaseEdit)control).Properties.ReadOnly = true;
                else
                    control.Enabled = false;
            }
        }

        public static void ClearGroupControlControls(Control groupControl)
        {
            foreach (var control in groupControl.Controls)
            {
                string type = control.GetType().Name;
                switch (type)
                {
                    case "TextBox":
                        ((TextBox)control).Text = "";
                        break;
                    case "TextEdit":
                        ((TextEdit)control).Text = "";
                        ((TextEdit)control).Properties.AccessibleName = "";
                        break;
                    case "GridLookUpEdit":
                        ((GridLookUpEdit)control).EditValue = null;
                        break;
                    case "DateEdit":
                        ((DateEdit)control).EditValue = null;
                        break;
                    case "TimeEdit":
                        ((TimeEdit)control).EditValue = null;
                        break;
                    case "PictureEdit":
                        ((PictureEdit)control).Image = null;
                        break;
                    case "ComboBoxEdit":
                        ((ComboBoxEdit)control).Text = "";
                        break;
                    case "MemoEdit":
                        ((MemoEdit)control).Text = "";
                        break;
                    case "CheckEdit":
                        ((CheckEdit)control).Checked = false;
                        break;
                }

            }
        }
        public static List<List<IEntity>> GetEntitiesFromExcel(string path, string kullaniciId, Control[] controls = null)
        {
            List<List<IEntity>> entityList = null;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
            xlApp.DisplayAlerts = false;

            try
            {
                xlWorkBook = xlApp.Workbooks.Open(path, ReadOnly: true);
                List<IEntity> entity;
                entityList = new List<List<IEntity>>();

                foreach (Worksheet sheet in xlWorkBook.Worksheets)
                {
                    //entity = GetEntityListFromExcelSheet(sheet, kullaniciId, controls);
                    //if (entity != null) entityList.Add(entity);
                    //else entityList = null;
                }
            }
            catch (Exception ex)
            {
                entityList = null;
                if (ex.GetBaseException().Message.IndexOf("İş parçacığı durduruluyordu") < 0)
                {
                    MessageBox.Show(ex.GetBaseException().Message);
                }
            }

            finally
            {
                xlApp.Quit();
                if (xlWorkBook != null) Marshal.FinalReleaseComObject(xlWorkBook);
                Marshal.FinalReleaseComObject(xlApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return entityList;
        }
        public static void UpdateControlText(Control control, string tableName, int completed, int total)
        {
            if (control.InvokeRequired)
            {
                UpdateControlTextDlg del = new UpdateControlTextDlg(UpdateControlText);
                control.Invoke(del, control, tableName, completed, total);
            }
            else
            {
                switch (control.Name)
                {
                    case "lblTablo":
                        control.Text = tableName;
                        break;
                    case "lblToplamKayit":
                        control.Text = total.ToString();
                        break;
                    case "lblAktarilanKayit":
                        control.Text = completed.ToString();
                        break;
                    case "lblYuzde":
                        control.Text = "%" + ((float)completed / (float)total * 100).ToString("f2");
                        break;
                    case "progressBar":
                        ((ProgressBarControl)control).Position = (int)((float)completed / (float)total * 100);
                        break;
                }
            }
        }
    }
}