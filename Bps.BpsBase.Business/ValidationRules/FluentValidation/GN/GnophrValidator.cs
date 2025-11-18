using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnophrValidator : AbstractValidator<GNOPHR>
    {
        #region ClientService

        #endregion ClientService

        public GnophrValidator()
        {
            RuleFor(p => p.TIPKOD).Length(1,20).NotNull();
            RuleFor(p => p.HARKOD).Length(1,20).NotNull();
            RuleFor(p => p.PARENT).NotNull();
            RuleFor(p => p.TANIMI).Length(1,50).NotNull();
            RuleFor(p => p.DVCNKD).MaximumLength(10);
            RuleFor(p => p.SIRASI).NotNull();
            RuleFor(p => p.GNICON).MaximumLength(50);
            RuleFor(p => p.EXTRA1).MaximumLength(250);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
