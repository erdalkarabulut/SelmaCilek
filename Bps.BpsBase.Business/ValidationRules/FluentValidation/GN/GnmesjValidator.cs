using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnmesjValidator : AbstractValidator<GNMESJ>
    {
        #region ClientService

        #endregion ClientService

        public GnmesjValidator()
        {
            RuleFor(p => p.LANGKD).Length(1,20).NotNull();
            RuleFor(p => p.MESJKD).Length(1,20).NotNull();
            RuleFor(p => p.MESJNO).Length(1,4).NotNull();
            RuleFor(p => p.MSTEXT).Length(1,-1).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
