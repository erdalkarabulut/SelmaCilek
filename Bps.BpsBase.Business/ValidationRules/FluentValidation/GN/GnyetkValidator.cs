using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnyetkValidator : AbstractValidator<GNYETK>
    {
        #region ClientService

        #endregion ClientService

        public GnyetkValidator()
        {
            RuleFor(p => p.KULKOD).Length(1,20).NotNull();
            RuleFor(p => p.PROKOD).Length(1,20).NotNull();
            RuleFor(p => p.MNUNAM).Length(1,50).NotNull();
            RuleFor(p => p.MNUTAG).NotNull();
            RuleFor(p => p.EKLEME).NotNull();
            RuleFor(p => p.DEGIST).NotNull();
            RuleFor(p => p.KAYDET).NotNull();
            RuleFor(p => p.SILMEK).NotNull();
            RuleFor(p => p.GRNTLM).NotNull();
            RuleFor(p => p.KOPYAL).NotNull();
            RuleFor(p => p.PDFGOS).NotNull();
            RuleFor(p => p.EXCGOS).NotNull();
            RuleFor(p => p.YAZDIR).NotNull();
            RuleFor(p => p.CSVGOS).NotNull();
            RuleFor(p => p.XMLGOS).NotNull();
            RuleFor(p => p.DOCGOS).NotNull();
            RuleFor(p => p.GNONAY).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
