using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnmenuValidator : AbstractValidator<GNMENU>
    {
        #region ClientService

        #endregion ClientService

        public GnmenuValidator()
        {
            RuleFor(p => p.PROKOD).Length(1,20).NotNull();
            RuleFor(p => p.MNUNAM).Length(1,50).NotNull();
            RuleFor(p => p.MNUTAG).NotNull();
            RuleFor(p => p.PARENT).NotNull();
            RuleFor(p => p.SIRASI).NotNull();
            RuleFor(p => p.GNICON).MaximumLength(50);
            RuleFor(p => p.GNAREA).MaximumLength(6);
            RuleFor(p => p.CONTNM).MaximumLength(50);
            RuleFor(p => p.FUNCNM).MaximumLength(50);
            RuleFor(p => p.FORNM).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
