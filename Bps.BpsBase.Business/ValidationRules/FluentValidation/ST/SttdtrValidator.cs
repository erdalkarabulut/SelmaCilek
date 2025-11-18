using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class SttdtrValidator : AbstractValidator<STTDTR>
    {
        #region ClientService

        #endregion ClientService

        public SttdtrValidator()
        {
            RuleFor(p => p.TEDKOD).Length(1,4).NotNull();
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.TEDTNM).Length(1,40).NotNull();
            RuleFor(p => p.YAPAYK).NotNull();
            RuleFor(p => p.FASONK).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
