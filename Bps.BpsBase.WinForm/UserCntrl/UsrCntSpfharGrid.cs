using Bps.BpsBase.Entities.Concrete.SP;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPS.Windows.Forms
{
    public partial class UsrCntSpfharGrid : UserControl
    {
        List<SPFHAR> _entityList = new List<SPFHAR>();
        public UsrCntSpfharGrid()
        {

            InitializeComponent();
            sPFHARBindingSource.DataSource = _entityList;
            gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            gridView1.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            gridView1.Appearance.FooterPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;

            // Footer yüksekliğini manuel büyüt (60 piksel yap)
            gridView1.LayoutChanged();

            gridView1.Columns["GNTUTR"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["GNTUTR"].SummaryItem.DisplayFormat = " ";
            // Custom draw olayını abone oluyoruz
            gridView1.CustomDrawFooterCell += GridView1_CustomDrawFooterCell;

        }
        private void GridView1_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            // Sadece belirli bir sütun için custom drawing yapalım (örneğin: "VergisizTutar")
            if (e.Column.FieldName == "GNTUTR")
            {
                //    // Hesaplamalarınızın sonucu; burada örnek sabit değerler kullanıyoruz,
                //    // normalde DataTable veya grid verisinden hesaplama yapmanız gerekebilir.
                //    decimal toplamVergisiz = CalculateTotalVergisizTutar();
                //    decimal toplamVergi = CalculateTotalVergi();
                //    decimal toplamTutar = CalculateTotalTutar();
                decimal vergisiz = 10;
                decimal vergi = 5;
                decimal tutar = CalculateTotalTutar();

                //    // Alt alta yazılacak metin
                string[] labels = { "Vergisiz Toplam:", "Toplam Vergi   :", "Toplam Tutar   :" };
                string[] values = { $"{vergisiz:C2}", $"{vergi:C2}", $"{tutar:C2}" };

                // Hücre yüksekliğini artır (60 piksel)
                RectangleF cellBounds = new RectangleF(e.Bounds.X, e.Bounds.Y, 200, 60);
                e.Graphics.FillRectangle(new SolidBrush(e.Appearance.BackColor), cellBounds);

                using (StringFormat sfLeft = new StringFormat(), sfRight = new StringFormat())
                using (Font boldFont = new Font(e.Appearance.Font, FontStyle.Bold)) // Kalın font
                {
                    // Metinler için sola hizalama
                    sfLeft.Alignment = StringAlignment.Near;
                    sfLeft.LineAlignment = StringAlignment.Center;
                    sfLeft.FormatFlags = StringFormatFlags.NoClip;

                    // Rakamlar için sağa hizalama
                    sfRight.Alignment = StringAlignment.Far;
                    sfRight.LineAlignment = StringAlignment.Center;
                    sfRight.FormatFlags = StringFormatFlags.NoClip;

                    // Satırların başlangıç yüksekliği
                    float yOffset = cellBounds.Y + 5; // Üstten boşluk bırak
                    float padding = 5; // Sağ ve sol boşluklar

                    foreach (var i in Enumerable.Range(0, labels.Length))
                    {
                        // Etiket (koyu ve sola hizalı)
                        RectangleF labelRect = new RectangleF(cellBounds.X + padding, yOffset, cellBounds.Width / 2 - padding, e.Appearance.Font.Height);
                        e.Graphics.DrawString(labels[i], boldFont, new SolidBrush(e.Appearance.ForeColor), labelRect, sfLeft);

                        // Değer (rakam) sağa hizalı, normal fontta
                        RectangleF valueRect = new RectangleF(cellBounds.X + cellBounds.Width / 2, yOffset, cellBounds.Width / 2 - padding, e.Appearance.Font.Height);
                        e.Graphics.DrawString(values[i], e.Appearance.Font, new SolidBrush(e.Appearance.ForeColor), valueRect, sfRight);

                        // Satır boşluğu
                        yOffset += e.Appearance.Font.Height + 2;
                    }
                }

                e.Handled = true; // Varsayılan çizimi engelle
            }
        }
        private decimal CalculateTotalTutar() 
        {
           decimal tutar = (decimal)_entityList.Sum(x=>x.GNTUTR);
           return tutar;
        }
    }



}
