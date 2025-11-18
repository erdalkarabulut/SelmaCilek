using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnevrkValidator : AbstractValidator<GNEVRK>
    {
        #region ClientService

        #endregion ClientService

        public GnevrkValidator()
        {
            RuleFor(p => p.TABLNM).Length(1,6).NotNull();
            RuleFor(p => p.TEKNAD).Length(1,6).NotNull();
            RuleFor(p => p.ISLTUR).NotNull();
            RuleFor(p => p.GNYEAR).NotNull();
            RuleFor(p => p.GNONEK).MaximumLength(10);
            RuleFor(p => p.KARSAY).NotNull();
            RuleFor(p => p.BASDEG).NotNull();
            RuleFor(p => p.BITDEG).NotNull();
            RuleFor(p => p.KALDEG).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
