using SolidWorks.Interop.sldworks;

namespace BOMex.Solidworks
{
    public class SheetMetal
    {
        public ModelDoc2 SheetBody;
        public bool Rotate;
        public double KisaKenar;
        public double UzunKenar;
        public int Adet;
        public double Thickness;
        public View View;

        //public SheetMetal(Body2 compDef, bool rotate, double kisaKenar, double uzunKenar, int adet)
        public SheetMetal(ModelDoc2 sheetBody, bool rotate, double kisaKenar, double uzunKenar, int adet, double thickness, View view = null)
        {
            SheetBody = sheetBody;
            Rotate = rotate;
            KisaKenar = kisaKenar;
            UzunKenar = uzunKenar;
            Adet = adet;
            Thickness = thickness;
            View = view;
        }
    }
}