using FluentValidation;
using Bps.BpsBase.Entities.Concrete.CR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.CR
{
    public class CrytklValidator : AbstractValidator<CRYTKL>
    {
        #region ClientService

        #endregion ClientService

        public CrytklValidator()
        {
            RuleFor(p => p.CRKODU).Length(1,25).NotNull();
            RuleFor(p => p.YETADI).Length(1,50).NotNull();
            RuleFor(p => p.YETSOY).Length(1,50).NotNull();
            RuleFor(p => p.YETUNV).MaximumLength(50);
            RuleFor(p => p.ISYTEL).MaximumLength(30);
            RuleFor(p => p.CRDHLN).MaximumLength(30);
            RuleFor(p => p.CEPTEL).MaximumLength(30);
            RuleFor(p => p.ISYFAX).MaximumLength(30);
            RuleFor(p => p.GNMAIL).MaximumLength(100);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
